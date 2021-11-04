using BD.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IRazaService
    {
        List<Raza> ObtenerTodos();
        void Crear(Raza raza);
        List<PerrosPorRaza> PerrosPorRaza();

    }
}
