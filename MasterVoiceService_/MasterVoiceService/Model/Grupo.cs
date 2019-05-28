using System;
using System.Collections.Generic;

namespace MasterVoiceService.Model
{
    public partial class Grupo
    {
        public Grupo()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
    }
}
