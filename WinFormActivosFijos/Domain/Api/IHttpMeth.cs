using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormActivosFijos.Domain.Meth
{
    public interface IHttpMeth
    {
        Task<string> GetHttp(string url);
    }
}
