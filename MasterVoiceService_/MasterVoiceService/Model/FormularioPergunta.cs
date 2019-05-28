using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class FormularioPergunta
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public int? IdQuestionario { get; set; }

        public FormularioQuestionario IdQuestionarioNavigation { get; set; }
    }
}
