using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyVault.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public int i = 0;

        public void OnGet()
        {
            
        }

        /* public void OnPost()
        {
            num1 = Int32.Parse(Request.Form["text1"]);
            num2 = Int32.Parse(Request.Form["text2"]);
            total = num1 + num2;
        } */

        public void OnPostAdd()
        {
            i = i + 1;
        }
    }
}
