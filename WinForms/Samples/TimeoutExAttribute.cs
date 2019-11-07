using System;

namespace Driver
{
    public class TimeoutExAttribute : Attribute
    {
        public int Time { get; set; }
        public TimeoutExAttribute(int timeout) { Time = timeout; }
    }
}
