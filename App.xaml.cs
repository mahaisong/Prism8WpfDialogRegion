using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Views;
using WpfApp1.Dialog;
using Prism.Services.Dialogs;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.ViewA>();
            containerRegistry.RegisterForNavigation<Views.ViewB>();


            //主要代码，开始
            containerRegistry.Register<DialogService, DialogRegionService>();
             

            //层级详细
            ///背景框-window
            containerRegistry.RegisterDialogWindow<Dialog1>("Dialog1");
            //嵌入的---主要布局--里面有region
            containerRegistry.RegisterDialog<KongJian>("KongJian");
            //主要布局内部的区域下--切换的view
            containerRegistry.RegisterForNavigation<Views.One>("One"); 
            containerRegistry.RegisterForNavigation<Views.Two>("Two");

        }
    }
}
