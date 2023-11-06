using Microsoft.AspNetCore.Mvc;
using Notifications.Bll;
using Notifications.Bll.Interfaces;
using Notifications.Bll.Notificacoes;
using System;
using System.Collections.Generic;

namespace Notifications.Api.Controllers
{
    [Route("api/clientes")]
    public class ClientesController : MainController
    {
        private readonly INotificador _notificador;

        public ClientesController(INotificador notificador) : base(notificador)
        {
            _notificador = notificador;
        }

        [HttpPost]
        [Route("AdicionarCliente")]
        public ActionResult AdicionarCliente([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CustomResponse(ModelState);
                }

                var cliente = new Clientes(_notificador);
                cliente.Nome = clienteDTO.Nome;
                cliente.Email = clienteDTO.Email;
                cliente.Idade = clienteDTO.Idade;

                cliente.AdicionarClienteEmMemoria(cliente);

                return CustomResponse(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar o cliente: {ex.Message}");
            }
        }

        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
            var result = Clientes.ObterClientesEmMemoria();
            return result;
        }
    }
}
