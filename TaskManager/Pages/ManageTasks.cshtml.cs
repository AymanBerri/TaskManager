using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TaskManager.Pages
{
    public class ManageTasks : PageModel
    {
        private readonly ILogger<ManageTasks> _logger;

        public ManageTasks(ILogger<ManageTasks> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}