using BD.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerrosController : ControllerBase
    {
        private IPerroService _perroService;
        public PerrosController(IPerroService perroService)
        {
            _perroService = perroService;
        }

        [HttpGet]
        public List<Perro> Get(int edad)
        {
            return _perroService.ObtenerMenores(edad);
        }
    }
}
