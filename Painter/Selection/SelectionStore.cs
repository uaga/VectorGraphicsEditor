using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class SelectionStore : List<Selection>
    {
        public void Release()
        {
            foreach (Selection selection in this)
            {
                selection.ReleaseGrab();
            }
        }
    }
}