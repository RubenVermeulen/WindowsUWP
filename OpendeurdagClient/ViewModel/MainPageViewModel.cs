using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpendeurdagClient.Helper;

namespace OpendeurdagClient.ViewModel
{
    class MainPageViewModel : ViewModelBase
    {
        public RelayCommand AllCampusesCommand { get; set; }
        public RelayCommand AllDegreesCommand { get; set; }

        public MainPageViewModel()
        {
            AllCampusesCommand = new RelayCommand(_ => ShowCampuses());
            AllDegreesCommand = new RelayCommand(_ => ShowDegrees());
        }

        private ViewModelBase currentData;

        public ViewModelBase CurrentData
        {
            get { return currentData;}
            set { currentData = value; RaisePropertyChanged(); }
        }

        private void ShowCampuses()
        {
            Debug.WriteLine("ShowCampuses command executed");

            CurrentData = new CampusViewModel();
        }

        private void ShowDegrees() {
            Debug.WriteLine("ShowDegrees command executed");

            CurrentData = new DegreeViewModel();

        }
    }
}
