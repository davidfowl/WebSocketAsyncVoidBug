using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication14
{
    /// <summary>
    /// Summary description for WebSocketTest
    /// </summary>
    public class WebSocketTest : HttpTaskAsyncHandler
    {
        public override Task ProcessRequestAsync(HttpContext context)
        {
            context.AcceptWebSocketRequest(socketContext =>
            {
                try
                {
                    Foo();
                }
                catch(Exception ex)
                {
                    socketContext.WebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(ex.Message)), WebSocketMessageType.Text, endOfMessage: true, cancellationToken: CancellationToken.None);
                }

                return Task.FromResult(0);
            });

            return Task.FromResult(0);
        }

        public async void Foo()
        {
        }
    }
}