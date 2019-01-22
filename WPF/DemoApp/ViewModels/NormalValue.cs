using System;

namespace DemoApp.ViewModels
{
    public class NormalValue
    {
        object _core;
        public NormalValue(object core) { _core = core; }
        public static implicit operator string(NormalValue src) => (string)src._core;
        public static implicit operator int(NormalValue src) => (int)src._core;
        public static implicit operator bool(NormalValue src) => (bool)src._core;
        public static implicit operator DateTime(NormalValue src) => (DateTime)src._core;
    }
}
