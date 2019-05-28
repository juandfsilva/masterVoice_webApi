using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterVoiceService.Model;
using Microsoft.AspNetCore.Mvc;

namespace MasterVoiceService.Negocio
{
    public class FormularioNegocio
    {
        public FormularioNegocio()
        {
                
        }

        public async Task<ActionResult<FormularioModel>> InterarFormulario(ActionResult<FormularioQuestionario> questionario, List<FormularioPergunta> perguntas, List<FormularioResposta> respostas)
        {
            FormularioModel formularioResult = new FormularioModel();
            formularioResult.Perguntas = new List<FormularioPergunta>();
            formularioResult.Respostas = new List<FormularioResposta>();

            formularioResult.Nome = questionario.Value.Nome;
            formularioResult.IdQuestionario = questionario.Value.Id;

            foreach (var x in perguntas)
            {
                FormularioPergunta z = new FormularioPergunta();

                z.Id = x.Id;
                z.IdQuestionario = x.IdQuestionario;
                z.Pergunta = x.Pergunta;

                formularioResult.Perguntas.Add(z);
            }

            foreach (var x in respostas)
            {
                FormularioResposta z = new FormularioResposta();

                z.Id = x.Id;
                z.IdQuestionario = x.IdQuestionario;
                z.Resposta = x.Resposta;
                z.PesoResposta = x.PesoResposta;

                formularioResult.Respostas.Add(z);
            }

            return formularioResult;
        }
    }
}
