using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterVoiceService.Model
{
    public class FormularioModel
    {
        public string Nome { get; set; }
        public int IdQuestionario { get; set; }
        public List<FormularioPergunta> Perguntas { get; set; }
        public List<FormularioResposta> Respostas { get; set; }
    }
}
