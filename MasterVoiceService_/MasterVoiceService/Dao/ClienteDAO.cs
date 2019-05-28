using MasterVoiceService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterVoiceService.Dao
{
    public class ClienteDAO
    {

        private readonly mastervoiceContext _context;

        public ClienteDAO(mastervoiceContext ctx)
        {
            _context = ctx;
        }

        public List<Cliente> BuscarClientesUsuarios(int idUsuario)
        {
           
            var result = _context.Cliente
                     .Where(X => X.IdUsuario == idUsuario)
                     .Select(cliente =>
                             new
                             {
                                idCliente = cliente.Id,
                                nome = cliente.Nome,
                                cpf = cliente.Cpf,
                                nascimento = cliente.Nascimento,
                                sexo = cliente.Sexo,
                                responsavel = cliente.Responsavel,
                                telefone = cliente.Telefone,
                                celular = cliente.Celular,
                                endereco = cliente.Endereco,
                                cidade = cliente.Cidade,
                                estado = cliente.Estado,
                                idGrupo = cliente.IdGrupo,
                                idUsuario = cliente.IdUsuario
                             }).ToList();

            if (result.Count > 0)
            {
                List<Cliente> cliente = new List<Cliente>();

                foreach (var x in result)
                {
                    Cliente cliente_ = new Cliente();

                    cliente_.Id = x.idCliente;
                    cliente_.Nome = x.nome;
                    cliente_.Cpf = x.cpf;
                    cliente_.Nascimento = x.nascimento;
                    cliente_.Sexo = x.sexo;
                    cliente_.Responsavel = x.responsavel;
                    cliente_.Telefone = x.telefone;
                    cliente_.Celular = x.celular;
                    cliente_.Endereco = x.endereco;
                    cliente_.Cidade = x.cidade;
                    cliente_.Estado = x.estado;
                    cliente_.IdGrupo = x.idGrupo;
                    cliente_.IdUsuario = x.idUsuario;

                    cliente.Add(cliente_);
                }
                return cliente;
            }
            else return null;
            
        }


        public async Task<ActionResult<Cliente>> BuscarCliente(int idCliente)
        {
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (cliente == null)
            {
                return null;
            }
            else return cliente;
          
        }

        public ActionResult<Cliente> AdicionarCliente(Cliente cliente)
        {
            if (BuscarClienteCpf(cliente.Cpf) == null)
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();

                return cliente;
            }
            else return null;
        }


        public ActionResult<Cliente> BuscarClienteCpf(string cpf)
        {
            Cliente cliente = new Cliente();
            var result = _context.Cliente
                       .Where(X => X.Cpf == cpf)
                       .Select(cli =>
                               new
                               {
                                   nome = cli.Nome,
                                   cpf = cli.Cpf,
                                   id = cli.Id
                               }).ToList();
            if (result.Count > 0)
            {
                foreach (var x in result)
                {
                    cliente.Nome = x.nome;
                    cliente.Cpf = x.cpf;
                    cliente.Id = x.id;

                }
                return cliente;
            }
            else return null;
        }
    }
}
