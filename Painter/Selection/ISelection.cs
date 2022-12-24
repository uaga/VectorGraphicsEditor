using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal interface ISelection
    {
        bool TryGrab(int x, int y);
        bool TryDrag(int x, int y);
        bool TrySelect(int x, int y);
        bool TryGroup(int x, int y);
        bool TryUnGroup(int x, int y);
        void Release();
        void SkipAll();
        void Repaint(DrawSystem drawSystem);
    }
}
