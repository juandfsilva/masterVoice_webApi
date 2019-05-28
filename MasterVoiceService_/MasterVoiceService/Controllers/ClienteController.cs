using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterVoiceService.Dao;
using MasterVoiceService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MasterVoiceService.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly mastervoiceContext _context;
        private ClienteDAO clienteDao;

        public ClienteController(mastervoiceContext ctx)
        {
            _context = ctx;
            clienteDao = new ClienteDAO(ctx);
        }

        [HttpGet ("buscarCliente/{idCliente}")]
        public async Task<ActionResult<Cliente>> BuscarCliente(int idCliente)
        {
            return await clienteDao.BuscarCliente(idCliente);
        }

        [HttpGet("buscarClientesUsuarios/{idUsuario}")]
        public async Task<List<Cliente>> BuscarClientesUsuarios(int idUsuario)
        {
            return  clienteDao.BuscarClientesUsuarios(idUsuario);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AdicionarCliente([FromBody] Cliente cliente)
        {
            if (clienteDao.AdicionarCliente(cliente) == null)
            {
                return BadRequest(new { Menssagem = "Cliente ja cadastrado para esse CPF" });
            }
            else return clienteDao.AdicionarCliente(cliente);
        }

    }
}