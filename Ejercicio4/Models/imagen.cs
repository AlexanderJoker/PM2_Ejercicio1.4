using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio4.Models
{
    public class imagen
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public Byte[] foto { get; set; }
    }
}
