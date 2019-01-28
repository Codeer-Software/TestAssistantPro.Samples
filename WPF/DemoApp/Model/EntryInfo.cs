using System;

namespace DemoApp.Model
{
    [Serializable]
    public class EntryInfo
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Language { get; set; }
        public bool IsMan { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
    }
}
