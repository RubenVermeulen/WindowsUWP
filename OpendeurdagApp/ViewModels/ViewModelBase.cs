using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using OpendeurdagApp.Helper;
using OpendeurdagApp.Models;

namespace OpendeurdagApp.ViewModels
{
    public class ViewModelBase : Template10.Mvvm.ViewModelBase
    {
        public User Auth => AuthService.User;

        public string AuthVisibility => Auth == null ? "Collapsed" : "Visible";
    }
}
