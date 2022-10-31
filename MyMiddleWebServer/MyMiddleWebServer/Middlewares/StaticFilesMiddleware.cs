using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.Middlewares
{
    public class StaticFilesMiddleware : IMiddleware
    {
        public HttpHandler Next { get; set; }

        public void Handle(HttpListenerContext context)
        {
            if (Path.HasExtension(context.Request.RawUrl))
            {
                try
                {
                    string filename = context.Request.RawUrl.Substring(1);
                    string path = $@"C:\Users\n.rasullu\Desktop\New folder\FBAS_1215_az\MyMiddleWebServer\MyMiddleWebServer\wwwroot\{filename}";
                    var bytes = File.ReadAllBytes(path);
                    if (Path.GetExtension(path) == ".htm")
                        context.Response.AddHeader("Content-Type", "text/htm");
                    else if (Path.GetExtension(path) == "webp")
                        context.Response.AddHeader("Content-Type", "image/webp");
                    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 404;
                    context.Response.StatusDescription = "File not found";
                }
            }
            else
                Next.Invoke(context);

            context.Response.Close();


        }
    }
}
