using MacroNutrientCalculatorV2.Models;
using MacroNutrientCalculatorV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MacroNutrientCalculatorV2.Controllers
{
        [Route("api/MacroNutrient")]
        [ApiController]
        public class MacroNutrientController : ControllerBase
        {
            private readonly CalculatorService _calculatorService;

            public MacroNutrientController(CalculatorService calculatorService)
            {
                _calculatorService = calculatorService;
            }

            [HttpPost("Calculate")]
            public IActionResult CalculateMacroNutrients([FromBody] MacroNutrientCalculationContainer input)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ServiceResult result = _calculatorService.MacroNutrientCalculation(input);

                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
        }
    }
