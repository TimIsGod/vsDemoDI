using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 依赖注入.Services
{
    public class Demo2Service : IDemoService
    {
        public void DemoFunc()
        {
            Console.WriteLine("This is Service Demo 2.");
        }
    }
}
