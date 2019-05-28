using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Login1 { get; set; }
        public string Senha { get; set; }
        public int IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
    }
}
