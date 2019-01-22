using System.Collections.Generic;

namespace DemoApp.Model
{
    public interface IModelDataManager
    {
        List<EntryInfo> EntryInfos { get; }
    }

    public class ModelDataManager : IModelDataManager
    {
        public List<EntryInfo> EntryInfos { get; set; } = new List<EntryInfo>();
    }
}
