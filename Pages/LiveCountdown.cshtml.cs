using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CountdownTimer.Pages
{
    public class LiveCountdownModel : PageModel
    {
        private readonly ILogger<LiveCountdownModel> _logger;

        public LiveCountdownModel(ILogger<LiveCountdownModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
