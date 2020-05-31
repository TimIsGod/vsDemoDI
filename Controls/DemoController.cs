using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using 依赖注入.Services;

namespace 依赖注入.Controls
{

    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoService _demoService;
        //通过用带参构造函数来使用注册的服务
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        [HttpGet]
        public void GetTestDemo()
        {
            _demoService.DemoFunc();
        }
    }
}