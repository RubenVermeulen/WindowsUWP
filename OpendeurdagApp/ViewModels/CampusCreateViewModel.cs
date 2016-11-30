using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpendeurdagApp.ViewModels
{
    public class CampusCreateViewModel : Template10.Mvvm.ViewModelBase
    {
        private HttpClient Client { get; set; }
    }
}
