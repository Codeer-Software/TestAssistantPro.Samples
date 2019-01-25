using System;
using System.Collections.Generic;

namespace DemoApp.Model
{
    public interface IModelDataManager
    {
        List<EntryInfo> EntryInfos { get; }
        Action Update { get; set; }
        void NotifyUpdate();
    }

    public class ModelDataManager : IModelDataManager
    {
        public List<EntryInfo> EntryInfos { get; set; } = new List<EntryInfo>();
        public Action Update { get; set; }

        public void NotifyUpdate() => Update?.Invoke();
    }
}
