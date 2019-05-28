using MasterVoiceService.Model;
using MasterVoiceService.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterVoiceService.Dao
{
    public class UsuarioDAO
    {
        private readonly mastervoiceContext _context;

        public UsuarioDAO(mastervoiceContext ctx)
        {
            _context = ctx;
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarAllUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> BuscarUsuario(int idUsuario)
        {
            var usuario = await _context.Usuario.FindAsync(idUsuario);
            if (usuario == null)
            {
                return null;
            }
            else return usuario;
        }

        public ActionResult<Usuario> BuscarUsuarioCpf(string cpf)
        {
            Usuario usuario = new Usuario();
            var result = _context.Usuario
                       .Where(X => X.Cpf == cpf)
                       .Select(usu =>
                               new
                               {
                                   nome = usu.Nome,
                                   cpf = usu.Cpf,
                                   id = usu.Id
                               }).ToList();
            if (result.Count > 0)
            {
                foreach (var x in result)
                {
                    usuario.Nome = x.nome;
                    usuario.Cpf = x.cpf;
                    usuario.Id = x.id;

                }
                return usuario;
            }
            else return null;
        }

        public async Task<ActionResult<UsuarioModelo>> AdicionarUsuario(UsuarioModelo usuario)
        {
            if (BuscarUsuarioCpf(usuario.Usuario.FirstOrDefault().Cpf) == null)
            {
                _context.Usuario.Add(new Usuario()
                {
                    Nome = usuario.Usuario.FirstOrDefault().Nome,
                    Cpf = usuario.Usuario.FirstOrDefault().Cpf

                });
                _context.SaveChanges();

                Login login = new Login();
                var idUsuario = BuscarUsuarioCpf(usuario.Usuario.FirstOrDefault().Cpf);
                login.Login1 = usuario.Login;
                login.Senha = usuario.Senha;
                login.IdUsuario = idUsuario.Value.Id;

                LoginDAO loginDAO = new LoginDAO(_context);
                await loginDAO.AdicionaLogin(login);
                
                return usuario;
            }
            else return null;

        }




    }
}
