using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatallaDeLosPenales.Servicios.Entidades
{
    public class DirectorTecnico : Entidad, IPuntuable
    {
        public string NombreUsuario { get; }
        private List<Jugador> Jugadores { get; }

        public int Puntos => Jugadores.Sum(jug => jug.Puntos);

        public DirectorTecnico()
        {

        }
        public DirectorTecnico(string nombreUsuario, List<Jugador> jugadores)
        {
            NombreUsuario = nombreUsuario;
            Jugadores = jugadores;

        }

        public List<Jugador> ObtenerJugadores()
        {
            return Jugadores;
        }

    }
}
