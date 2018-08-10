using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.T4Runtime
{
    class Program
    {
        static void Main(string[] args)
        {           
            string[] list = new string[] { "asaas", "asaas", "12323" ,"hello world","123456789012345678901234567890"};
            MyTempalte tm = new MyTempalte(list);
            string str = tm.TransformText();
        }
    }
}
