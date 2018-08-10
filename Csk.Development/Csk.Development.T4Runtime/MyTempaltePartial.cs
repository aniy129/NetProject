using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.T4Runtime
{
    public partial class MyTempalte
    {
        public string[] items { get; set; }
        public MyTempalte(string[] items)
        {
            this.items = items;
        }

    }
}
