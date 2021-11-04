using System;
using System.Collections.Generic;

#nullable disable

namespace BD.EF
{
    public partial class Raza
    {
        public Raza()
        {
            Perros = new HashSet<Perro>();
        }

        public int IdRaza { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Perro> Perros { get; set; }
    }
}
