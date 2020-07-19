using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Drogueria.Api.Hubs
{
    public class NotificacionesHub : Hub
    {
        public async Task EnviarMensaje(string mensaje)
        {
            await Clients.All.SendAsync("Mensaje", mensaje);
        }
    }
}
