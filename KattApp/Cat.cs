using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattApp.Mdoels
{
    public class Cat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        public string Birthday { get; set; }
        public string Food_type { get; set; }
       // public int Food_amount { get; set; }
        public double Weight { get; set; }
        public string Comment { get; set; }
    }
}
