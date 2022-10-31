using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.ActionResults
{
    public interface IActionResult
    {
        void ExecuteResult(HttpListenerContext context);
    }
}
