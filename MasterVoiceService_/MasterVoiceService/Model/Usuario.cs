using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cliente = new HashSet<Cliente>();
            Login = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Login> Login { get; set; }
    }
}
