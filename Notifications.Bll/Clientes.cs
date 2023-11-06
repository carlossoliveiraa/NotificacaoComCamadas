using Notifications.Bll.Interfaces;
using Notifications.Bll.Services;
using Notifications.Bll.Validacoes;

namespace Notifications.Bll
{
    public class Clientes : BaseService
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
               

        private static List<Clientes> clientesEmMemoria = new List<Clientes>();

        public Clientes(INotificador notificador) : base(notificador)
        {
        }

        public void AdicionarClienteEmMemoria(Clientes cliente)
        {

            if (!ExecutarValidacao(new ClientesValidation(), cliente))
                return;
                       
            int novoId = clientesEmMemoria.Count + 1;
            

            clientesEmMemoria.Add(cliente);
        }

        public static IEnumerable<Clientes> ObterClientesEmMemoria()
        {
            return clientesEmMemoria;
        }
    }
}





