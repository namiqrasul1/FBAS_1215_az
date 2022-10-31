using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.ActionResults
{
    public class ViewResult : IActionResult
    {
        public void ExecuteResult(HttpListenerContext context)
        {
            var sections = context?.Request?.RawUrl?.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var folderName = sections[0];
            var fileName = sections[1];
            var helperPath = $"{Directory.GetCurrentDirectory().Split("\\bin")[0]}";
            var path = $"{helperPath}/Views/{folderName}/{fileName}.html";
            var bytes = File.ReadAllBytes(path);
            context.Response.ContentType = "text/html";
            context.Response.OutputStream.Write(bytes);
        }
    }
}
