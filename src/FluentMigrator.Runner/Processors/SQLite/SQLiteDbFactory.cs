namespace FluentMigrator.Runner.Processors.SQLite
{
    public class SQLiteDbFactory : ReflectionBasedDbFactory
    {
        public SQLiteDbFactory()
#if !NETSTANDARD2_0
            : base("System.Data.SQLite", "System.Data.SQLite.SQLiteFactory")
#else
            : base("Microsoft.Data.Sqlite", "Microsoft.Data.Sqlite.SqliteFactory")
#endif
        {
        }
    }
}