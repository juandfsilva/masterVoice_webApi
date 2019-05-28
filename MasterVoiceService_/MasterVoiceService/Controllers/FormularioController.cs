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
    public class FormularioController : Controller
    {
        private readonly mastervoiceContext _context;
        private FormularioDAO formularioDAO;

        public FormularioController(mastervoiceContext ctx)
        {
            _context = ctx;
            formularioDAO = new FormularioDAO(ctx);
        }

        [HttpGet("buscarQuestionarios")]
        public async Task<ActionResult<List<FormularioQuestionario>>> BuscarQuestionarios()
        {
            return await formularioDAO.BuscarQuestionarios();
        }

        [HttpGet("{idQuestionario}")]
        public async Task<ActionResult<List<FormularioPergunta>>> BuscaPerguntas(int idQuestionario)
        {

            return formularioDAO.BuscaPerguntas(idQuestionario);
        }

        [HttpGet("buscarFormulario/{idQuestionario}")]
        public async Task<ActionResult<FormularioModel>> BuscaFormularioCompleto(int idQuestionario)
        {
            var formulario = formularioDAO.BuscaFormularioCompleto(idQuestionario);
            if (formulario == null || formulario.Result == null)
            {
                return NotFound(new { Menssagem = "Formulario não encontrado" });
            }
            else return await formulario;
        }

        [HttpPost("dadosLink")]
        public async Task<List<DadosLinkModel>> RetornaDadosLink([FromBody] QuestionarioClienteModel questionarioClienteModel)
        {
            return formularioDAO.RetornaDadosLink(questionarioClienteModel.IdQuestionario, questionarioClienteModel.IdCliente);
        }

        
    }
}