using DemoApp.Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using VVMConnection;

namespace DemoApp.ViewModels
{
    public class AllDisplayControlViewModel : BindableBase
    {
        public class EntryInfoDataGridRowVM : INotifyPropertyChanged
        {
            internal EntryInfo Core { get; }
            public string Name { get { return GetCore(); } set { SetCore(value); } }
            public string Mail { get { return GetCore(); } set { SetCore(value); } }
            public string Language { get { return GetCore(); } set { SetCore(value); } }
            public string Sex
            {
                get
                {
                    return Core.IsMan ? "Man" : "Woman";
                }
                set
                {
                    var isMan = (value == "Man");
                    if (isMan != Core.IsMan)
                    {
                        Core.IsMan = isMan;
                        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Sex)));
                    }
                }
            }
            public DateTime BirthDay { get { return GetCore(); } set { SetCore(value); } }

            public event PropertyChangedEventHandler PropertyChanged = (_, __) => { };

            public EntryInfoDataGridRowVM(EntryInfo core)
            {
                Core = core;
            }

            void SetCore(object objNew, [CallerMemberName] string name = "")
            {
                var objSrc = Core.GetType().GetProperty(name).GetValue(Core);
                if (!Equals(objSrc, objNew))
                {
                    Core.GetType().GetProperty(name).SetValue(Core, objNew);
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
            NormalValue GetCore([CallerMemberName] string name = "")
                => new NormalValue(Core.GetType().GetProperty(name).GetValue(Core));
        }

        List<EntryInfo> _infos;
        IRegionManager _regionManager;

        public Func<bool> GetVisible { get; set; }
        public Notify<string> NameSearch { get; set; } = new Notify<string>();
        public Notify<string> LanguageSearch { get; set; } = new Notify<string>();
        public Notify<EntryInfoDataGridRowVM> SelectedItem { get; set; } = new Notify<EntryInfoDataGridRowVM>();
        public ObservableCollectionEx<EntryInfoDataGridRowVM> EntryInfos { get; set; } = new ObservableCollectionEx<EntryInfoDataGridRowVM>();

        public Func<bool?> AskDelete { get; set; }

        public AllDisplayControlViewModel(IRegionManager regionManager, IModelDataManager mgr)
        {
            _infos = mgr.EntryInfos;
            _infos.ForEach(e => EntryInfos.Add(new EntryInfoDataGridRowVM(e)));
            _regionManager = regionManager;
        }

        public void Search()
        {
            if (!GetVisible()) return;

            IEnumerable<EntryInfo> result = _infos.ToArray();
            if (!NameSearch.IsNullOrEmpty()) result = result.Where(e => e.Name.ToLower().Contains(NameSearch.Value.ToLower()));
            if (!LanguageSearch.IsNullOrEmpty()) result = result.Where(e => e.Language == LanguageSearch.Value);
            EntryInfos.Clear();
            result.ToList().ForEach(e => EntryInfos.Add(new EntryInfoDataGridRowVM(e)));
        }

        public void Add() => _regionManager.RequestNavigate("ContentRegion", "EntryControl");

        public void Delete()
        {
            if (SelectedItem.Value == null) return;
            if (AskDelete() != true) return;
            _infos.Remove(SelectedItem.Value.Core);
            Search();
        }
    }
}
