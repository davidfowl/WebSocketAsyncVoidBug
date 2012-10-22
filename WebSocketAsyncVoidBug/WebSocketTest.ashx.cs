using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication14
{
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
                    // The exception is thrown here, we're just sending the message back to the socket
                    // so we can disply something in the client.
                    return socketContext.WebSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(ex.Message)), WebSocketMessageType.Text, endOfMessage: true, cancellationToken: CancellationToken.None);
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