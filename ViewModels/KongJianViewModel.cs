using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using WpfApp1.Dialog;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class KongJianViewModel : BindableBase, IDialogAware
    {
        event Action<IDialogResult> IDialogAware.RequestClose
        {
            add
            {

            }

            remove
            {

            }
        }

        bool IDialogAware.CanCloseDialog()
        {
            return true;
        }

        void IDialogAware.OnDialogClosed()
        {

            _regionManager.Regions.Remove("rm");
        }

        /// <summary>
        /// 被打开时--得到新建的区域
        /// </summary>
        /// <param name="parameters"></param>
        void IDialogAware.OnDialogOpened(IDialogParameters parameters)
        { 
              if (parameters.TryGetValue<IRegionManager>("rm", out IRegionManager rm))
                _regionManager = rm;

            if (parameters.TryGetValue<string>("XRegionInView", out string v))
                _regionManager.RequestNavigate(RegionName, v);
            //else----我不处理初始化加载的事
            //    _regionManager.RequestNavigate("CustomDialogARegion", "CustomDialogAAView");
        }

        private string RegionName = "jiujiujiuRegion";

        public DelegateCommand ShowOneViewCommand { get; private set; }
        public DelegateCommand ShowTwoViewCommand { get; private set; }

        public DialogService _dialogRegionService { get; private set; }
        public IRegionManager _regionManager { get; private set; }

        string IDialogAware.Title => throw new NotImplementedException();

        public KongJianViewModel(IRegionManager regionManager, DialogService dialogRegionService)
        {
            _regionManager = regionManager;
            _dialogRegionService = dialogRegionService;
             

            ShowOneViewCommand = new DelegateCommand(() =>
            {
                _regionManager.Regions[RegionName].RequestNavigate("One");  
            });
            ShowTwoViewCommand = new DelegateCommand(() =>
            {
                _regionManager.Regions[RegionName].RequestNavigate("Two");

                //regionManager.RequestNavigate(RegionName, "Two");
 
            });

        }

        
    }
}
