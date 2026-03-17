using Microsoft.EntityFrameworkCore;
using Portafolio.Context;
using Portafolio.Model;
using Portafolio.Repositorie.Interfaces;

namespace Portafolio.Repositorie
{
    public class UsuarioRepositorie : IUsuario
    {
        private readonly ContextDB _context;
        public UsuarioRepositorie(ContextDB context)
        {
            _context = context;
        }
        public async Task<List<Usuario>> GetUsuario()
        {
            var data = await _context.Usuario.ToListAsync();
            return data;
        }

        public async Task<bool> PostUsuario(Usuario user)
        {
            await _context.Usuario.AddAsync(user);
            var res = _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PutUsuario(Usuario user)
        {
            _context.Usuario.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var user = await _context.Usuario.FirstAsync(u => u.Id == id);
            _context.Usuario.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
