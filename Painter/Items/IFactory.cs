using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal interface IFactory
    {
        ItemType ItemType { get; set; }
        void CreateAndGrab(int x, int y);
        Item CreateItem(int x, int y);
    }
}
