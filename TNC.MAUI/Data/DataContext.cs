using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNC.MAUI.Models;

namespace TNC.WPF.Data
{
    internal class DataContext : DbContext
    {

        public DataContext()
        {
            //SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        public DbSet<Person> People { get; set; }
       
        //public DbSet<Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                // SQL Server connection with port
                //optionsBuilder.UseSqlServer("Server=localhost,63027;Database=UserDatabase;Trusted_Connection=True;");

                // SQL Server connection with localdb
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserDatabase;Trusted_Connection=True;");

                // SQL Server connection from App.config
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TNCAndroid;Trusted_Connection=True;");

                //optionsBuilder.UseSqlServer("Server=WIN-PO9SVP3KRMT\\MSSQLSERVER01,63027;Database=TNCAndroid;Trusted_Connection=True;");

                
                
                // SQlite
                //optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["ConnectionSQLite"].ToString());
                optionsBuilder.UseSqlite(@"DataSource=TNCAndroid.db;");
                //string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TNCAndroid.db3");
                //optionsBuilder.UseSqlite($"Filename={dbPath}");
            }
        }

    }
}
