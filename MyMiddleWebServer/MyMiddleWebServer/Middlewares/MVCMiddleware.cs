using MyMiddleWebServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.Middlewares
{
    public class MVCMiddleware : IMiddleware
    {
        public HttpHandler? Next { get ; set; }

        public void Handle(HttpListenerContext context)
        {
            string? url = context.Request.RawUrl;
            if (!string.IsNullOrEmpty(url))
            {
                var sections = url.Split('/', StringSplitOptions.RemoveEmptyEntries);

                var controllerName = $"MyMiddleWebServer.Controllers.{sections[0]}Controller";
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type? type = assembly.GetType(controllerName);
                if (type != null)
                {
                    Controller? controllerObj = Activator.CreateInstance(type) as Controller;
                    if (controllerObj != null)
                    {
                        string methodName = sections[1];
                        controllerObj.Context = context;
                        MethodInfo? methodInfo = type.GetMethod(methodName);
                        methodInfo?.Invoke(controllerObj, null);
                    }
                }
            }
            Next?.Invoke(context);
        }
    }
}
