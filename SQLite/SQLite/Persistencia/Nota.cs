using System;
using System.Collections.Generic;
using System.Text;

namespace SQLite.Persistencia
{
    public class Nota
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }
    }
}
