using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DemoApp
{
    public class BlockControl : Control
    {
        List<Rectangle> _blocks = new List<Rectangle>();
        int _selectedIndex = -1;
        Bitmap _buf;
        Point? _dragPos;
        Stopwatch _time;

        public event EventHandler SelectChanged;
        public event EventHandler<BlockMoveEventArgs> BlockMoved;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex == value) return;
                _selectedIndex = value;
                Invalidate();
                SelectChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public BlockControl()
        {
            DoubleBuffered = true;
            try
            {
                _buf = new Bitmap(Width, Height);
            }
            catch { }
        }

        public void AddBlock(Rectangle rect)
        {
            _blocks.Add(rect);
            Invalidate();
        }

        public void MoveBlock(int index, Point location)
        {
            _blocks[index] = new Rectangle(location, _blocks[index].Size);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var pos = e.Location;
            _dragPos = null;
            for (int i = _blocks.Count - 1; 0 <= i; i--)
            {
                if (_blocks[i].Contains(pos))
                {
                    SelectedIndex = i;
                    _dragPos = e.Location;
                    _time = new Stopwatch();
                    _time.Start();
                    break;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_dragPos == null) return;
            _time.Stop();
            if (_time.ElapsedMilliseconds < 100) return;

            var xlen = e.Location.X - _dragPos.Value.X;
            var yLen = e.Location.Y - _dragPos.Value.Y;
            var src = _blocks[SelectedIndex];
            _blocks[SelectedIndex] = new Rectangle(src.X + xlen, src.Y + yLen, src.Width, src.Height);
            BlockMoved?.Invoke(this, new BlockMoveEventArgs { MoveIndex = SelectedIndex, MoveLocation = _blocks[SelectedIndex].Location });
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_buf != null) _buf.Dispose();
            _buf = new Bitmap(Width, Height);
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var g = Graphics.FromImage(_buf))
            {
                g.FillRectangle(Brushes.White, 0, 0, Width, Height);
                for (int i = 0; i < _blocks.Count; i++)
                {
                    g.FillRectangle(Brushes.GreenYellow, _blocks[i]);
                    if (i == SelectedIndex)
                    {
                        g.DrawRectangle(Pens.Red, _blocks[i]);
                    }
                }
                g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            }
            e.Graphics.DrawImage(_buf, new Point());
        }
    }
}
