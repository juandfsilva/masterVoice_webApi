using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class FormularioQuestionario
    {
        public FormularioQuestionario()
        {
            ClienteResultado = new HashSet<ClienteResultado>();
            FormularioPergunta = new HashSet<FormularioPergunta>();
            FormularioResposta = new HashSet<FormularioResposta>();
            FormularioResultado = new HashSet<FormularioResultado>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<ClienteResultado> ClienteResultado { get; set; }
        public ICollection<FormularioPergunta> FormularioPergunta { get; set; }
        public ICollection<FormularioResposta> FormularioResposta { get; set; }
        public ICollection<FormularioResultado> FormularioResultado { get; set; }
    }
}
