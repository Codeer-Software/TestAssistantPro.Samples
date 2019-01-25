using DemoApp.Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using VVMConnection;

namespace DemoApp.ViewModels
{
    public class EntryControlViewModel : BindableBase
    {
        List<EntryInfo> _infos;
        IRegionManager _regionManager;

        public Notify<string> Name { get; set; } = new Notify<string>();
        public Notify<string> Mail { get; set; } = new Notify<string>();
        public Notify<string> Language { get; set; } = new Notify<string>();
        public Notify<bool> IsMan { get; set; } = new Notify<bool>();
        public Notify<bool> IsWoman { get; set; } = new Notify<bool>();
        public Notify<DateTime?> BirthDay { get; set; } = new Notify<DateTime?>();

        public event EventHandler Registed = (_, __) => { };

        public Func<bool?> NotifyDataError { get; set; }

        public EntryControlViewModel(IRegionManager regionManager, IModelDataManager mgr)
        {
            _infos = mgr.EntryInfos;
            _regionManager = regionManager;
        }

        public void Entry()
        {
            if (Name.IsNullOrEmpty() || Mail.IsNullOrEmpty() || Language.IsNullOrEmpty() || BirthDay.Value == null)
            {
                NotifyDataError();
                return;
            }
            if (IsMan.Value == IsWoman.Value)
            {
                NotifyDataError();
                return;
            }
            _infos.Add(new EntryInfo()
            {
                Name = Name.Value,
                Mail = Mail.Value,
                Language = Language.Value,
                IsMan = IsMan.Value,
                BirthDay = BirthDay.Value.Value
            });
            //Name.Value = Mail.Value = Language.Value = string.Empty;
            IsMan.Value = IsWoman.Value = false;
            BirthDay.Value = null;
            Registed(this, EventArgs.Empty);

            _regionManager.RequestNavigate("ContentRegion", "AllDisplayControl");
        }

        public void Cancel()
            => _regionManager.RequestNavigate("ContentRegion", "AllDisplayControl");
    }
}
