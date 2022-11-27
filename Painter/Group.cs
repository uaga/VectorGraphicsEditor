using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    internal class Group : Item
    {
        List<Item> objects;
        public override void Draw(DrawSystem painter)
        {
            foreach (Item item in objects)
            {
                item.Draw(painter);
            }
        }
        public Group(List<Item> objs) : base(GetFrame(objs))
        {
            objects = objs;
        }
        static private Frame GetFrame(List<Item> objs)
        {
            //int[] min = { 1000000, 1000000 };
            //int[] max = { -1, -1 };

            //foreach (GraphObj item in objs)
            //{
            //    if (item.frame)
            //    {

            //    }
            //}

            return new Frame(10, 10, 10, 10);
        }
    }
}
