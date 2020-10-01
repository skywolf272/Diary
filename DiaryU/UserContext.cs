using System.Data.Entity;

namespace DiaryU
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        { }

        public DbSet<Title_> TitleClasses { get; set; }
        public DbSet<Title_Daily> title_Dailies { get; set; }
    }
}
