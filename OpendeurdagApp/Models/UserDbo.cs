using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpendeurdagApp.Models
{
    public class UserDbo
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        public string UserName { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
    }
}
