using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteResultado = new HashSet<ClienteResultado>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int IdGrupo { get; set; }
        public int? IdUsuario { get; set; }

        public Grupo IdGrupoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<ClienteResultado> ClienteResultado { get; set; }
    }
}
