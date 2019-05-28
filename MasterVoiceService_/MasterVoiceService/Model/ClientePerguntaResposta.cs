using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class ClientePerguntaResposta
    {
        public int Id { get; set; }
        public int IdPergunta { get; set; }
        public int IdResposta { get; set; }
        public int IdCliente { get; set; }
        public string DataPreenchimento { get; set; }
        public int Respondido { get; set; }
    }
}
