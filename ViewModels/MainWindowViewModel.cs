using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using WpfApp1.Dialog;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand ShowACommand { get; private set; }
        public DelegateCommand ShowBCommand { get; private set; }

        public DelegateCommand ShowDialog1Command { get; private set; } 

        public DialogService _dialogRegionService { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, DialogService dialogRegionService)
        {

            _dialogRegionService = dialogRegionService;
            ShowACommand = new DelegateCommand(() =>regionManager.RegisterViewWithRegion("View1Region", "ViewA"));
            ShowBCommand = new DelegateCommand(() =>regionManager.RegisterViewWithRegion("View2Region", "ViewB"));

            ShowDialog1Command = new DelegateCommand(() =>
            { 
                _dialogRegionService.Show("KongJian", new DialogParameters { { "XRegionInView", "One" } }, _ => { }, "Dialog1"); 
            });

        }
    }
}
