using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterVoiceService.Dao;
using MasterVoiceService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasterVoiceService.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly mastervoiceContext _context;
        private UsuarioDAO usuarioDao;
        public UsuarioController(mastervoiceContext ctx)
        {
            _context = ctx;
            usuarioDao = new UsuarioDAO(ctx);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarAllUsuarios()
        {
            return await usuarioDao.BuscarAllUsuarios();
        }

        [HttpGet("buscarUsuario/{idUsuario}")]
        public async Task<ActionResult<Usuario>> BuscarUsuario(int idUsuario)
        {
            return await usuarioDao.BuscarUsuario(idUsuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModelo>> AdicionarUsuario([FromBody] UsuarioModelo usuario)
        {
            return await usuarioDao.AdicionarUsuario(usuario);
        }


    }
}