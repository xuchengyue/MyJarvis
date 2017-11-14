using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyJarvis
{
    public class Concept
    {

    }

    public class IdeaLink
    {
        private List<CustomQueue> link;

        public void add(object obj)
        {
            CustomQueue last = this.link.Last();
            CustomQueue queue = new CustomQueue()
            {
                id = last.id + 1,
                content = obj,
                previous = last.id
            };
        }
    }

    public class CustomQueue
    {
        public int id { get; set; }

        public object content { get; set; }

        public int previous { get; set; }

        public int next { get; set; }
    }
}
