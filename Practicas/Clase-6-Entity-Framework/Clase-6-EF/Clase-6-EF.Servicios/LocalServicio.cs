using Clase_6_EF.Data.EF;
using Clase_6_EF.Data.Repositorios;
using Clase_6_EF.Data.Repositorios.Interfaces;
using Clase_6_EF.Servicios.Interfaces;
using System;
using System.Collections.Generic;

namespace Clase_6_EF.Servicios
{
    public class LocalServicio : ILocalServicio
    {
        private ILocalRepositorio _localRepo;

        public LocalServicio(ILocalRepositorio localRepo)
        {
            _localRepo = localRepo;
        }

        public List<Local> ObtenerTodos()
        {
            return _localRepo.ObtenerTodos();
        }

        public void Agregar(Local local)
        {
            _localRepo.Agregar(local);
            _localRepo.SaveChanges();
        }

        public Local ObtenerPorId(int idLocal)
        {
           return _localRepo.ObtenerPorId(idLocal);
        }
        public void Borrar(int idLocal)
        {
            Local local = ObtenerPorId(idLocal);
            if (local == null)
                throw new ArgumentException("No se puede borrar el local, ya que no se encuentra disponible.");
            
            _localRepo.Borrar(local);
            _localRepo.SaveChanges();
        }

        public void Modificar(Local local)
        {
            if (local == null)
                throw new ArgumentException("No se puede modificar el local");

            Local localEnDB = ObtenerPorId(local.IdLocal);
            if (local == null)
                throw new ArgumentException("No se puede borrar el local, ya que no se encuentra disponible.");

            localEnDB.Nombre = local.Nombre;
            localEnDB.Direccion = local.Direccion;

            _localRepo.SaveChanges();
        }

        public void SaveChanges()
        {
            _localRepo.SaveChanges();
        }
    }
}
