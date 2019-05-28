using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class FormularioResposta
    {
        public int Id { get; set; }
        public string Resposta { get; set; }
        public int? PesoResposta { get; set; }
        public int? IdQuestionario { get; set; }

        public FormularioQuestionario IdQuestionarioNavigation { get; set; }
    }
}
