using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite.iOS.Persistencia;
using SQLite.Persistencia;
using UIKit;
using Xamarin.Forms;
[assembly: Dependency(typeof(SQLiteDb))]

namespace SQLite.iOS.Persistencia
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}