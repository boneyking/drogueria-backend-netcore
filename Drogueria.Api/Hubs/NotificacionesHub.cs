using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
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
