using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Samples.Controllers
{
    public class DataTableController : ParentController
    {
        private readonly ILogger<DataTableController> _logger;
        public DataTableController(ILogger<DataTableController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
