# Prism8WpfDialogRegion
我的极简写法：Prism 在弹出的 Dialog Window下面Region 无法实现切换。 采用重新 创建1个子级的region就可以切换

最主要的，几个点。
1.关于注入， 需要有 ABView被注入成为【FOR】Navigate---其实是userControl
             需要有 含有区域--里面套着 ABVIEW 的  AView 注册为 DialogWindows---其实是userControl
2.需要有1个DialogService。 并注入register。
             重点是override 重写其中1个方法 ConfigureDialogWindowContent
             执行这个方法，可以达到show时，内部创建1个新的子regionManager， 并且将这个rm对象作为参数向下传递。
             -----------后面使用这个rm引用。而不是通用的RegionManager。
3.要注意，在ABVIEW里面有一个IDialogAware.OnDialogOpened 方法，在打开时，负责从参数拿到rm对象，通过rm对象来做导航nagivation操作。

