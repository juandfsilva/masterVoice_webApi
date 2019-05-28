using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class FormularioResultado
    {
        public int Id { get; set; }
        public int? IdQuestionario { get; set; }
        public int? RangeIni { get; set; }
        public int? RangeFim { get; set; }
        public string Resultado { get; set; }

        public FormularioQuestionario IdQuestionarioNavigation { get; set; }
    }
}
