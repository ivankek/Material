using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_6_EF.Web.Logic
{
    public class OperacionesLogic : IOperacionesLogic
    {
        private const string OPERACION_KEY = "OPERACION";

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public OperacionesLogic(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Agregar(string operacion)
        {
            _session.SetString(OPERACION_KEY, operacion);
        }

        public string Obtener()
        {
            return _session.GetString(OPERACION_KEY);
        }
    }
}
