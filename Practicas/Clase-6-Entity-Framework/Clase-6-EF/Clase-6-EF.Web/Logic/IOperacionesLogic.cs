using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_6_EF.Web.Logic
{
    public interface IOperacionesLogic
    {
        public void Agregar(string operacion);
        public string Obtener();
    }
}
