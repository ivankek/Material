using System;
using System.Collections.Generic;

#nullable disable

namespace BD.EF
{
    public partial class Perro
    {
        public int IdPerro { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public int IdRaza { get; set; }

        public virtual Raza IdRazaNavigation { get; set; }
    }
}
