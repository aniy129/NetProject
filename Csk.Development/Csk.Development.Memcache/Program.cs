using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csk.Development.Memcache
{
    class Program
    {
        static void Main(string[] args)
        {
            MemcacheHelper.Set("key", 12345);
            var obj = MemcacheHelper.Get("key");
        }
    }
}
