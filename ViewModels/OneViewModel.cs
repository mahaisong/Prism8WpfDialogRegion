using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace WpfApp1.ViewModels
{
    public class OneViewModel : BindableBase, INavigationAware// IConfirmNavigationRequest
    {
        public string Name { get; set; } = "One";

        //void IConfirmNavigationRequest.ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        //{

        //    bool result = true;

        //    if (MessageBox.Show("确认是否要离开AAAAAAAAAAAAAAAA当前模块？", "系统提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
        //    {
        //        result = false;
        //    }

        //    continuationCallback(result);
        //}

        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
