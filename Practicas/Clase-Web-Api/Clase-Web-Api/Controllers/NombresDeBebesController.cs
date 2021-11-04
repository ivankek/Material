using Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clase_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombresDeBebesController : ControllerBase
    {
        private static List<NombreBebe> _lista = new List<NombreBebe>() 
        {
           new NombreBebe()
           {
               Id = 1,
               Nombre = "Olivia",
               Origen = "Viene del latín. Como puedes imaginar su raíz tiene que ver con el olivo, que son los árboles autóctonos del Mediterráneo, y simbolizan la paz. De ahí que en las alegorías las palomas lleven una ramita de olivo en el pico, como símbolo de la paz",
               Signifado = "Significa pacífica."
           },
           new NombreBebe()
           {
               Id = 2,
               Nombre = "Abril",
               Origen = "De origen latino.",
               Signifado = "Que recibe el sol en primavera."
           },
           new NombreBebe()
           {
               Id = 3,
               Nombre = "Argentina",
               Origen = "plata.",
               Signifado = "Proviene del latín argentum. Encontramos su registro escrito en la expresión Terra Argentea incluida en una pieza cartográfica del portugués Lopo Homen de 1554. Existen testimonios confiables de la época que dan cuenta de la asociación existente por entonces entre el territorio y el Río de la Plata, pero es en 1602 que la aparición de un libro habría de fijar la denominación."
           },
        };
        // GET: api/<NombresDeBebesController>
        [HttpGet]
        public IEnumerable<NombreBebe> Get()
        {
            return _lista;
        }

        // GET api/<NombresDeBebesController>/5
        [HttpGet("{id}")]
        public NombreBebe Get(int id)
        {
            return _lista.FirstOrDefault(o=> o.Id == id);
        }

        // POST api/<NombresDeBebesController>
        [HttpPost]
        public void Post([FromBody] NombreBebe item)
        {
            if (!_lista.Exists(o => string.Equals(o.Nombre, item.Nombre, StringComparison.CurrentCultureIgnoreCase)));
            {
                _lista.Add(item);
            }
        }

        // PUT api/<NombresDeBebesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NombreBebe item)
        {
            int index = _lista.FindIndex(o => o.Id == id);
            if (index >= 0)
            {
                _lista[index] = item;
            }
        }

        // DELETE api/<NombresDeBebesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _lista.RemoveAll(o => o.Id == id);
        }
    }
}
