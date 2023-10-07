using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PrimeraPrueba.EN;

namespace PrimeraPrueba.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Roles pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Roles pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Roles.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                rol.Nombre = pRol.Nombre;
                bdContexto.Update(rol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Roles pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Roles.FirstOrDefaultAsync(s => s.Id == pRol.Id);
                bdContexto.Roles.Remove(rol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Roles> ObtenerPorIdAsync(Roles pRol)
        {
            var rol = new Roles();
            using (var bdContexto = new BDContexto())
            {
                rol = await bdContexto.Roles.FirstOrDefaultAsync(s => s.Id == pRol.Id);
            }
            return rol;
        }
        public static async Task<List<Roles>> ObtenerTodosAsync()
        {
            var roles = new List<Roles>();
            using (var bdContexto = new BDContexto())
            {
                roles = await bdContexto.Roles.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Roles> QuerySelect(IQueryable<Roles> pQuery, Roles pRol)
        {
            if (pRol.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pRol.Id);

            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Roles>> BuscarAsync(Roles pRol)
        {
            var roles = new List<Roles>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Roles.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }
    }
}
