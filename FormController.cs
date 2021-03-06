﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAura.PolymorphicBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {

        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SaveForm([FromBody]Form form)
        {
            return new ObjectResult(new { });
        }
    }
}
