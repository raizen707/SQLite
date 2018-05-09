using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace SQLite.Persistencia
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
