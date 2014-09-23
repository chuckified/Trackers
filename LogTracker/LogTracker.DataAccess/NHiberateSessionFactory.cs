using System;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace LogTracker.DataAccess
{
    public static class NHibernateSessionFactory
    {
        private static bool ShowSql
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ShowSql"]); }
        }

        private static string SchemaOutputPath
        {
            get { return ConfigurationManager.AppSettings["SchemaOutputPath"]; }
        }

        public static ISessionFactory CreateSessionFactory(string connectionStringKey)
        {
            return ConfigureNHibernate(connectionStringKey).BuildSessionFactory();
        }

        private static FluentConfiguration ConfigureNHibernate(string connectionStringKey)
        {
            return Fluently
                .Configure()
                .Database(ConfigureDatabase(connectionStringKey))
                .Mappings(ConfigureMappings)
                .ExposeConfiguration(GetExportSchemaAction(SchemaOutputPath));
        }


        private static IPersistenceConfigurer ConfigureDatabase(string connectionStringKey)
        {
            var configuration = MsSqlConfiguration
                .MsSql2008
                .ConnectionString(c => c.FromConnectionStringWithKey(connectionStringKey));

            return ShowSql ? configuration.ShowSql() : configuration;
        }

        private static void ConfigureMappings(MappingConfiguration configuration)
        {
            configuration
                .FluentMappings.AddFromAssemblyOf<Domain.Log>()
                .Conventions.Add(ForeignKey.EndsWith("Id"));
        }

        private static Action<Configuration> GetExportSchemaAction(string schemaOutputFile)
        {
            return string.IsNullOrWhiteSpace(schemaOutputFile)
                ? (Action<Configuration>)null
                : ExportSchema;
        }

        private static void ExportSchema(Configuration configuration)
        {
            var schemaExport = new SchemaExport(configuration);
            schemaExport.SetOutputFile(SchemaOutputPath);
            schemaExport.Execute(false, true, false);
        }
    }
}