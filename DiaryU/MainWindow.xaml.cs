using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace DiaryU
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] Button_themes;
        Button[] Button_themes_daily;
        List<Title_> title_list = new List<Title_>();
        List<Title_Daily> title_daily_list = new List<Title_Daily>();

        int tag_for_button_theme = -2;
        int tag_for_button_theme_daily = -2;



        public MainWindow()
        {
            InitializeComponent();

            TimerOptionsOn();

            Button_themes = new Button[1000]; // Массив кнопок, который содержит темы и отображется как темы на панели
            Button_themes_daily = new Button[1000]; // Такой же массив только для тем, которые используются на день

            using (UserContext context = new UserContext()) // подключение к БД
            {
                FillStackPanel(context);

                FillStackPanelDaily(context);

            }
            DataPicker1.SelectedDate = DateTime.Today;
        }

        private void NewTheme(object sender, RoutedEventArgs e)
        {
            TitleNameForm titleNameForm = new TitleNameForm();

            titleNameForm.ShowDialog();
            if (titleNameForm.title_Name != "")
            {
                Title_ title_new = new Title_();
                title_new.Title = titleNameForm.title_Name;

                using (UserContext context = new UserContext())
                {
                    context.TitleClasses.Add(title_new);
                    context.SaveChanges();
                    FillStackPanel(context);
                }
            }
        }

        private void DeleteTheme(object sender, RoutedEventArgs e)
        {
            if (tag_for_button_theme != -2)
            {
                MessageBox.Show(tag_for_button_theme.ToString() + " " + title_list[tag_for_button_theme].Title);
                using (UserContext context = new UserContext())
                {
                    int id_delete = title_list[tag_for_button_theme].Id;
                    var title = context.TitleClasses.FirstOrDefault(alp => alp.Id == id_delete);
                    context.TitleClasses.Remove(title);
                    context.SaveChanges();
                    FillStackPanel(context);
                    tag_for_button_theme = -2;
                }
            }
        }

        private void OpenTheme(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            tag_for_button_theme = Convert.ToInt32(btn.Tag);;
            TextBoxContent1.Text = title_list[Convert.ToInt32(btn.Tag)].title_content;
        }

        private void DataPicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            using (UserContext context = new UserContext())
            {
                FillStackPanelDaily(context);
            }
        }


        private void FillStackPanel(UserContext userContext)
        {
            StackPanelUs.Children.Clear();
            title_list = userContext.TitleClasses.ToList(); //Преобразование данных из таблицы БД в лист в программе
            for (int i = 0; i < title_list.Count; i++) //Заполнение панели кнопками с темами
            {
                Button_themes[i] = new Button();
                Button_themes[i].Height = 28;
                Button_themes[i].Click += OpenTheme;
                Button_themes[i].Content = title_list[i].Title;
                Button_themes[i].Tag = i;
                StackPanelUs.Children.Add(Button_themes[i]);
            }
        }

        private void FillStackPanelDaily(UserContext userContext)
        {
            StackPanelDaily.Children.Clear();
            title_daily_list = userContext.title_Dailies.ToList(); //Преобразование данных из таблицы тем которые используются на день
            for (int i = 0; i < title_daily_list.Count; i++)
            {
                if (title_daily_list[i].title_date == DataPicker1.SelectedDate.ToString()) //Заполнение панели кнопками с темами на день
                {
                    Button_themes_daily[i] = new Button();
                    Button_themes_daily[i].Height = 28;
                    Button_themes_daily[i].Click += OpenThemeDaily;
                    Button_themes_daily[i].Content = title_daily_list[i].TitleD;
                    Button_themes_daily[i].Tag = i;
                    StackPanelDaily.Children.Add(Button_themes_daily[i]);
                }
            }
        }

        private void TimerOptionsOn()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += SaveAll;
            timer.Tick += SaveAllDaily;
            timer.Start();
        }

        private void SaveAll(object sender, EventArgs e)
        {
            if (tag_for_button_theme != -2)
            {
                title_list[tag_for_button_theme].title_content = TextBoxContent1.Text;
                using (UserContext context = new UserContext())
                {
                    int id_to_change = title_list[tag_for_button_theme].Id;
                    var title = context.TitleClasses.FirstOrDefault(al => al.Id == id_to_change);
                    title.title_content = title_list[tag_for_button_theme].title_content;
                    context.SaveChanges();
                    MessageBox.Show("Сохранено вроде");
                }
            }
        }

         private void SaveAllDaily(object sender, EventArgs e)
        {
     
            if (tag_for_button_theme_daily != -2)
            {
                title_daily_list[tag_for_button_theme_daily].title_contentD = TextBoxContent1.Text;
                using (UserContext context = new UserContext())
                {
                    int id_to_changeD = title_daily_list[tag_for_button_theme_daily].Id;
                    var titleDai = context.title_Dailies.FirstOrDefault(alo => alo.Id == id_to_changeD);
                    titleDai.title_contentD = title_daily_list[tag_for_button_theme_daily].title_contentD;
                    context.SaveChanges();
                    MessageBox.Show("Сохранено вроде но другое");
                }
            }
        }

        private void NewThemeDaily(object sender, RoutedEventArgs e)
        {
            TitleNameForm titleNameForm = new TitleNameForm();

            titleNameForm.ShowDialog();
            if (titleNameForm.title_Name != "")
            {
                Title_Daily title_new_daily = new Title_Daily();
                title_new_daily.TitleD = titleNameForm.title_Name;
                title_new_daily.title_date = DataPicker1.SelectedDate.ToString();

                using (UserContext context = new UserContext())
                {
                    context.title_Dailies.Add(title_new_daily);
                    context.SaveChanges();
                    FillStackPanelDaily(context);
                }
            }
        }

        private void DeleteThemeDaily(object sender, RoutedEventArgs e)
        {
            if (tag_for_button_theme_daily != -2)
            {
                MessageBox.Show(tag_for_button_theme_daily.ToString() + " " + title_daily_list[tag_for_button_theme_daily].TitleD);
                using (UserContext context = new UserContext())
                {
                    int id_deleti = title_daily_list[tag_for_button_theme_daily].Id;
                    var titleDa = context.title_Dailies.FirstOrDefault(belp => belp.Id == id_deleti);
                    context.title_Dailies.Remove(titleDa);
                    context.SaveChanges();
                    FillStackPanelDaily(context);
                    tag_for_button_theme_daily = -2;
                }
            }
        }

        private void OpenThemeDaily(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            tag_for_button_theme_daily = Convert.ToInt32(btn.Tag);
            TextBoxContent1.Text = title_daily_list[Convert.ToInt32(btn.Tag)].title_contentD;
            MessageBox.Show(tag_for_button_theme_daily.ToString());
        }
    }
}
