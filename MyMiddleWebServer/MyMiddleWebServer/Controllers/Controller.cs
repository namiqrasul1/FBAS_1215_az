using MyMiddleWebServer.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleWebServer.Controllers
{
    public abstract class Controller
    {
        public HttpListenerContext Context { get; set; }

        public ViewResult View()
        {
            var result = new ViewResult();
            result.ExecuteResult(Context);
            return result;
        }
    }
}
