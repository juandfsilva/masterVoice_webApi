using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class ClienteResultado
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdQuestionario { get; set; }
        public int Resultado { get; set; }
        public string DataResposta { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public FormularioQuestionario IdQuestionarioNavigation { get; set; }
    }
}
