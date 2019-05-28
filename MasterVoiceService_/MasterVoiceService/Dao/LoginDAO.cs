using MasterVoiceService.Model;
using MasterVoiceService.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterVoiceService.Dao
{
    public class LoginDAO
    {
        private readonly mastervoiceContext _context;

        public LoginDAO(mastervoiceContext ctx)
        {
            _context = ctx;
        }

        public async Task<ActionResult<Login>> AdicionaLogin(Login login)
        {

            _context.Login.Add(new Login()
            {
                Login1 = login.Login1,
                Senha = Criptografia.Codifica(login.Senha),
                IdUsuario = login.IdUsuario
            });
            _context.SaveChanges();

            return login;
            
        }

        public async Task<ActionResult<Login>> BuscarLogin(string login)
        {
            var result = _context.Login
                       .Where(X => X.Login1 == login)
                       .Select(log =>
                               new
                               {
                                   login = log.Login1,
                                   senha = log.Senha,
                                   idUsuario = log.IdUsuario
                               }).ToList();

            if (result.Count > 0)
            {
                Login loginResult = new Login();
                foreach (var x in result)
                {
                    loginResult.Login1 = x.login;
                    loginResult.Senha = x.senha;
                    loginResult.IdUsuario = x.idUsuario;
                }

                return loginResult;
            }
            else return null;

        }

    }
}
