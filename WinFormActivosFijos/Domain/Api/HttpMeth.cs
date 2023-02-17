using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormActivosFijos.Domain.Meth
{
    public class HttpMeth :IHttpMeth
    {
        public async Task<string> GetHttp(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }
    }
}
