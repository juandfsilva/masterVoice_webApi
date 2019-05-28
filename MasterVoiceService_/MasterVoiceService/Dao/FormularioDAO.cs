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
    public class FormularioDAO
    {
        private readonly mastervoiceContext _context;
        private readonly FormularioNegocio formularioNegocio;

        public FormularioDAO(mastervoiceContext ctx)
        {
            _context = ctx;

            this.formularioNegocio = new FormularioNegocio();

        }

        public async Task<ActionResult<FormularioQuestionario>> BuscaQuestionario(int idQuestionario)
        {
            var questionario = await _context.FormularioQuestionario.FindAsync(idQuestionario);
            if (questionario == null)
            {
                return null;
            }

            else return questionario;
        }

        internal static void AtualizarRespostas(List<ClientePerguntaResposta> clientePerguntaResposta)
        {
            foreach (var questionario in clientePerguntaResposta)
            {
                foreach(questionario in  )
            }
        }

        public async Task<ActionResult<List<FormularioQuestionario>>> BuscarQuestionarios()
        {
            var t = await _context.FormularioQuestionario.ToListAsync();
            return t;
        }

        public List<FormularioPergunta> BuscaPerguntas(int idQuestionario)
        {
            var result = _context.FormularioPergunta
                       .Where(X => X.IdQuestionario == idQuestionario)
                       .Select(pergunta =>
                               new
                               {
                                   pergunta = pergunta.Pergunta,
                                   idPergunta = pergunta.Id,
                                   idQuestionario = pergunta.IdQuestionario
                               }).ToList();
            if (result.Count > 0)
            {
                List<FormularioPergunta> perguntas = new List<FormularioPergunta>();
                
                foreach (var x in result)
                {
                    FormularioPergunta perguntas_ = new FormularioPergunta();
                    perguntas_.Id = x.idPergunta;
                    perguntas_.Pergunta = x.pergunta;
                    perguntas_.IdQuestionario = x.idQuestionario;

                    perguntas.Add(perguntas_);

                }
                return perguntas;
            }
            else return null;
        }

        public List<int> BuscaIdPergunta(int idQuestionario)
        {
            var result = _context.FormularioPergunta
                       .Where(X => X.IdQuestionario == idQuestionario)
                       .Select(pergunta =>
                               new
                               {
                                   idPergunta = pergunta.Id
                                   
                               }).ToList();

            if (result.Count > 0)
            {
                List<int> idPerguntas = new List<int>();

                foreach (var x in result)
                {
                    idPerguntas.Add(x.idPergunta);
                }
                return idPerguntas;
            }
            else return null;
        }

        public List<FormularioResposta> BuscarRespostas(int idQuestionario)
        {
            var result = _context.FormularioResposta.Where
                    (x => x.IdQuestionario == idQuestionario).Select(resposta =>
                        new
                        {

                            idResposta = resposta.Id,
                            descResposta = resposta.Resposta,
                            pesoResposta = resposta.PesoResposta

                        }).ToList();
            if (result.Count > 0)
            {
                List<FormularioResposta> respostasResult = new List<FormularioResposta>();

                foreach (var x in result)
                {
                    FormularioResposta z = new FormularioResposta();
                    z.Resposta = x.descResposta;
                    z.Id = x.idResposta;
                    z.PesoResposta = x.pesoResposta;

                    respostasResult.Add(z);
                }
                return respostasResult;
            }

            return null;
        }


        public DadosLinkModel GravarDadosLink(List<int> idPergunta, int idCliente)
        {
            DadosLinkModel respostaClienteModel = new DadosLinkModel();

            var maxId = _context.ClientePerguntaResposta.Select(p => p.Id).DefaultIfEmpty(0).Max();

            foreach (var x in idPergunta)
            {
                try
                {
                    _context.ClientePerguntaResposta.Add(new ClientePerguntaResposta()
                    {
                        Id = maxId + 1,
                        IdCliente = idCliente,
                        IdPergunta = x,
                    });
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                }
                
            }
            
            respostaClienteModel.IdCliente = idCliente;
            respostaClienteModel.IdResposta = maxId + 1;

            return respostaClienteModel;
            
        }

        public List<DadosLinkModel> RetornaDadosLink(List<int> idQuestionario, int idCliente)
        {
            List<DadosLinkModel> listaDadosLink = new List<DadosLinkModel>();

            foreach (var x in idQuestionario)
            {
                List<int> idPerguntas = BuscaIdPergunta(x);
                var dadosLinks = GravarDadosLink(idPerguntas, idCliente);
                dadosLinks.IdQuestionario = x;

                listaDadosLink.Add(dadosLinks);


            }

            return listaDadosLink;
        }

        public async Task<ActionResult<FormularioModel>> BuscaFormularioCompleto(int idQuestionario)
        {
            var questionario = await BuscaQuestionario(idQuestionario);
            var perguntas = BuscaPerguntas(idQuestionario);
            var respostas = BuscarRespostas(idQuestionario);

            if (questionario != null && perguntas != null && respostas != null)
            {
                return await formularioNegocio.InterarFormulario(questionario, perguntas, respostas);
            }
            else return null;
            
        }

    }
}
