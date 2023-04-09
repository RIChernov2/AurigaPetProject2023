using AurigaPetProject2023.DataAccess.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AurigaPetProject2023.DataAccess.Helpers
{
    public static class DateBaseHelper
    {
        internal static string GetConnectionString()
        {
            #region OLD CODE
            //var builder = new ConfigurationBuilder();
            //// установка пути к текущему каталогу
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //// получаем конфигурацию из файла appsettings.json
            //builder.AddJsonFile("appsettings.json");
            //// создаем конфигурацию
            //var config = builder.Build();
            //// получаем строку подключения
            //string connectionString = config.GetConnectionString("Default"); ;

            //return connectionString;
            #endregion

            // Создаем конфигурацию
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            string connectionString = configuration.GetConnectionString("Default"); ;
            return connectionString;
        }

        // необходимо наличие БД AurigaPetProject2023 в локальном Sql Server
        public static void RunStartMigration()
        {
            using (var serviceProvider = CreateServices())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    // Put the database update into a scope to ensure
                    // that all resources will be disposed.
                    UpdateDatabaseMigrationUp(scope.ServiceProvider);
                }
            }            
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()                
                .AddFluentMigratorCore()   //Add FluentMigrator.Runner
                .ConfigureRunner(rb => rb
                    //Add MySql 5.0 support
                    .AddSqlServer()
                    //Configure connection string
                    //.WithGlobalConnectionString("server=localhost;port=3307;Database=abc;UID=root;PWD=123456")
                    .WithGlobalConnectionString($"{GetConnectionString()}")
                    //Retrieve the migration configuration
                    //.ScanIn(typeof(AddLogTable).Assembly).For.Migrations())
                    .ScanIn(typeof(AddProductTypes).Assembly).For.Migrations())
                //Enable console log
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                //Build a service provider
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabaseMigrationUp(IServiceProvider serviceProvider)
        {
            //Initialize the in-process migration builder
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            //Execute migration script
            runner.MigrateUp();
            //runner.Up(new AddProductTypes());
        }
    }
}
