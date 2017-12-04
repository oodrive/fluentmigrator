
namespace FluentMigrator.Runner.Processors
{
    using System.Reflection;
    using System.Data.Common;

    public class ReflectionBasedDbFactory : DbFactoryBase
    {
        private readonly string assemblyName;
        private readonly string dbProviderFactoryTypeName;

        public ReflectionBasedDbFactory(string assemblyName, string dbProviderFactoryTypeName)
        {
            this.assemblyName = assemblyName;
            this.dbProviderFactoryTypeName = dbProviderFactoryTypeName;
        }

        protected override DbProviderFactory CreateFactory()
        {
#if !NETSTANDARD2_0
            return (DbProviderFactory)System.AppDomain.CurrentDomain.CreateInstanceAndUnwrap(assemblyName, dbProviderFactoryTypeName);
#else
            return (DbProviderFactory) Assembly.Load(assemblyName).CreateInstance(dbProviderFactoryTypeName, true,
                BindingFlags.NonPublic | BindingFlags.Instance, null, null,
                System.Globalization.CultureInfo.CurrentCulture, null);
#endif
        }
    }
}