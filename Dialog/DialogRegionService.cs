using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Dialog
{
    /// <summary>
    /// 父类必须是DialogService
    /// </summary>

    public class DialogRegionService : DialogService
    {
        private readonly IContainerExtension _containerExtension;
        private readonly IRegionManager _regionManager;
        public DialogRegionService(
            IContainerExtension containerExtension
            , IRegionManager regionManager) : base(containerExtension)
        {
            _containerExtension = containerExtension;
            _regionManager = regionManager;
        }


        protected override void ConfigureDialogWindowContent(string dialogName, IDialogWindow window, IDialogParameters parameters)
        {
            //创建1个新的子级的regionManager 区域管理器
            var rm = _regionManager.CreateRegionManager();
            //将1个Window 和 rm这个子级的 区域管理器 进行关联
            RegionManager.SetRegionManager(window as Window, rm);
            RegionManager.UpdateRegions();

            //将新的子级管理器rm，作为同名的参数传递。---》下面被打开的页面，可以拿到这个rm对象。
            parameters.Add("rm", rm);

            base.ConfigureDialogWindowContent(dialogName, window, parameters);
        }

    }

}
