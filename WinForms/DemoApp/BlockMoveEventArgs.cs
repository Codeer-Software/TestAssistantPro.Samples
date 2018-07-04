using System;
using System.Drawing;

namespace DemoApp
{
    public class BlockMoveEventArgs : EventArgs
    {
        public int MoveIndex { get; set; }
        public Point MoveLocation { get; set; }
    }
}
