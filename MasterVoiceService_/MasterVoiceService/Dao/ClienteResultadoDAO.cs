using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterVoiceService.Model;

namespace MasterVoiceService.Dao
{
    public class ClienteResultadoDAO
    {
        private mastervoiceContext context;

        public ClienteResultadoDAO(mastervoiceContext ctx)
        {
            context = ctx;
        }
    }
}
