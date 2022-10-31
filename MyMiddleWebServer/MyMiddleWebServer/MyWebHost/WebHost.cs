using MyMiddleWebServer.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.MyWebHost
{
    public class WebHost
    {
        private int _port;
        private HttpHandler _handler;
        private MiddlewareBuilder _middlewareBuilder = new();
        private HttpListener _listener;

        public WebHost(int port)
        {
            _port = port;
            _listener = new();
            _listener.Prefixes.Add($"http://localhost:{_port}/");
        }
        
        public void UseStartup<T>() where T : IStartup, new()
        {
            IStartup startup = new T();

            startup.Configure(_middlewareBuilder);

            _handler = _middlewareBuilder.Build();
        }

        public void Run()
        {
            _listener.Start();

            Console.WriteLine($"Server started on port {_port}");

            while (true)
            {
                HttpListenerContext context = _listener.GetContext();
                Task.Run(() => HandlerRequest(context));
            }
        }

        private void HandlerRequest(HttpListenerContext context)
        {
            _handler.Invoke(context);
        }
    }
}
