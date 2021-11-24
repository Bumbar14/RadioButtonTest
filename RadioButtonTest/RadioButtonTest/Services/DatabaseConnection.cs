using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadioButtonTest.Model;

namespace RadioButtonTest.Services
{
    public class DatabaseConnection
    {
        public const string DBFileName = "TEST.db";
        static public string databasePathEmbeddedResources
        {
            get
            {
                string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBFileName);
                return databasePath;

            }
        }

        // Connection to use flags
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        // Create SQLite connection named Database and create tables

        static SQLiteAsyncConnection Database;
        
        static public readonly AsyncLazy<DatabaseConnection> Instance = new AsyncLazy<DatabaseConnection>(async () =>
        {
            var instance = new DatabaseConnection();
            CreateTableResult result = await Database.CreateTableAsync<Category>();
            return instance;
        });
        
        public DatabaseConnection ()
        {
            Database = new SQLiteAsyncConnection(databasePathEmbeddedResources, Flags);
        }


        // Databse CRUD operations

        public Task<List<Category>> GetAllCategories()
        {
            return Database.Table<Category>().ToListAsync();
        }
        public async Task<int> SaveOrUpdateCategory(Category item)
        {
            List<Category> categoriesInDB= await GetAllCategories();
            if (categoriesInDB.Exists(c => c.CategoryID == item.CategoryID))
            {
                return Database.UpdateAsync(item).Result;
            }
            else
            {
                return Database.InsertAsync(item).Result;
            }
        }
        public Task<int> DeleteCategory(Category item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
