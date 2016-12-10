using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.Config
{
    class Config
    {
        public static string BaseUrl => "http://localhost:5385/";
        public static string BaseUrlApi => BaseUrl + "api/";
    }
}
