using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeraPrueba.DAL;
using PrimeraPrueba.EN;

namespace PrimeraPrueba.BL
{
    public class RolBL
    {
        public async Task<int> CrearAsync(Roles pRol)
        {
            return await RolDAL.CrearAsync(pRol);
        }

        public async Task<int> ModificarAsync(Roles pRol)
        {
            return await RolDAL.ModificarAsync(pRol);
        }

        public async Task<int> EliminarAsync(Roles pRol)
        {
            return await RolDAL.EliminarAsync(pRol);
        }
        public async Task<Roles> ObtenerPorIdAsync(Roles pRol)
        {
            return await RolDAL.ObtenerPorIdAsync(pRol);
        }

        public async Task<List<Roles>> ObtenerTodosAsync()
        {
            return await RolDAL.ObtenerTodosAsync();
        }

        public async Task<List<Roles>> BuscarAsync(Roles pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }
}
