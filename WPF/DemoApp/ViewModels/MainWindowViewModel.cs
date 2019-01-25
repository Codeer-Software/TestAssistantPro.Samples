using DemoApp.Model;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO;

namespace DemoApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        List<EntryInfo> _infos;
        IModelDataManager _dataMgr;
        IRegionManager _regionManager;

        public Func<string> AskSaveFilePath { get; set; }
        public Func<string> AskOpenFilePath { get; set; }
        public Func<string, bool?> NotifyInfo { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, IModelDataManager dataMgr)
        {
            _regionManager = regionManager;
            _dataMgr = dataMgr;
            _infos = dataMgr.EntryInfos;
        }

        public void CreateNewData()
        {
            _infos.Clear();
            _dataMgr.NotifyUpdate();
            _regionManager.RequestNavigate("ContentRegion", "AllDisplayControl");
        }

        public void OpenFile()
        {
            var path = AskOpenFilePath();
            if (path.IsNullOrEmpty()) return;
            _infos.Clear();
            try
            {
                _infos.AddRange(JsonConvert.DeserializeObject<List<EntryInfo>>(File.ReadAllText(path)));
            }
            catch (Exception e)
            {
                NotifyInfo(e.Message);
            }
            _dataMgr.NotifyUpdate();
        }

        public void OpenSave()
        {
            var path = AskSaveFilePath();
            if (path.IsNullOrEmpty()) return;
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(_infos, Formatting.Indented));
            }
            catch (Exception e)
            {
                NotifyInfo(e.Message);
            }
        }
    }
}
