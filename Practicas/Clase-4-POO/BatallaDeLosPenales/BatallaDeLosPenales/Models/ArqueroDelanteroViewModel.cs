using BatallaDeLosPenales.Servicios.Servicios;
using BatallaDeLosPenales.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatallaDeLosPenales.Models
{
    public class ArqueroDelanteroViewModel
    {

        public List<Arquero> todosLosArqueros { get; set; }

        public List<Delantero> todosLosDelanteros { get; set; }

        public ArqueroDelanteroViewModel()
        {

        }

        public ArqueroDelanteroViewModel(List<Arquero> listaArqueros, List<Delantero> listaDelanteros)
        {

            todosLosArqueros = listaArqueros;
            todosLosDelanteros = listaDelanteros;

        }

    }
}
