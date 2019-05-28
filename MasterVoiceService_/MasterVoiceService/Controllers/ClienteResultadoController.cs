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
    public class ClienteResultadoController : Controller
    {
        private readonly mastervoiceContext _context;
        private readonly ClienteResultadoDAO clienteResultadoDao;

        public ClienteResultadoController(mastervoiceContext ctx)
        {
            _context = ctx;
            clienteResultadoDao = new ClienteResultadoDAO(ctx);
        }

        public ActionResult GerarResultado(List<ClientePerguntaResposta> clientePerguntaResposta)
        {
            FormularioDAO.AtualizarRespostas(clientePerguntaResposta);


            return null;
        }

        
    }

  
}