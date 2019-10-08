using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CountdownTimer.Pages
{
    public class CountdownModel : PageModel
    {
        private readonly ILogger<CountdownModel> _logger;

        public CountdownModel(ILogger<CountdownModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            ViewData["countdown"] = string.Empty;
            return Page();
        }

        public async Task<IActionResult> OnPost(string userDate)
        {
            GetDaysRemaining(userDate);
            if (userDate == null)
                ViewData["countdown"] = "No date entered";

            return Page();
        }

        public DateTime Validate(string userDate)
        {
            DateTime countdownDate;

            if (!string.IsNullOrEmpty(userDate))
            {
                try
                {
                    DateTime.TryParse(userDate, out countdownDate);
                    return countdownDate < DateTime.Today ? DateTime.Today : countdownDate;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Could not parse date", ex);
                }
            }
            return DateTime.MinValue;
        }

        public string GetDaysRemaining(string userDate)
        {
            DateTime validDate = Validate(userDate);

            ViewData["countdown"] = 0;
            ViewData["dateEntered"] = $"{validDate:d}";

            if (validDate != DateTime.MinValue)
            {
                ViewData["countdown"] = validDate.Subtract(DateTime.Now.Date).Days;
            }

            return ViewData["countdown"].ToString() + "days";
        }
    }
}
