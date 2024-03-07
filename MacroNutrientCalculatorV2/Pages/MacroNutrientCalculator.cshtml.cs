using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MacroNutrientCalculatorV2.Pages
{
    public class MacroNutrientCalculatorModel : PageModel
    {
        private readonly ILogger<MacroNutrientCalculatorModel> _logger;

        public MacroNutrientCalculatorModel(ILogger<MacroNutrientCalculatorModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
