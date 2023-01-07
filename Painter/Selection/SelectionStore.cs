using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class SelectionStore : List<Selection>
    {
        public Selection ActiveSelection { get; set; }
        public void Release()
        {
            ActiveSelection= null;
            Clear();
        }
    }
}