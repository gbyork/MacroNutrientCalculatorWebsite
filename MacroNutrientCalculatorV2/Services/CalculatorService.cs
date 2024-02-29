using MacroNutrientCalculatorV2.Models;


namespace MacroNutrientCalculatorV2.Services
{

    /// <summary>
    /// Information provided by https://www.healthline.com/nutrition/how-to-count-macros#macros . Will be using the following Calcs
    /// Males: calories/day = 10 x weight (kilograms, or kg) + 6.25 x height (centimeters, or cm) – 5 x age (years) + 5
    /// Females: calories/day = 10 x weight(kg) + 6.25 x height(cm) – 5 x age(years) – 161
    /// </summary>
    public class CalculatorService 
    {
        public ServiceResult MacroNutrientCalculation(MacroNutrientCalculationContainer input)
        {
            ServiceResult result = new ServiceResult
            {
                Success = true,
                Message = "woohoo"
            };
            return result;
        }

        public double CalculateFatIntake (int weight)
        {
            double fatIntake = weight * 0.5;
            return fatIntake;
        }

        public double CalculateCalorieIntake (MacroNutrientCalculationContainer input) 
        {
            int height = getTotalHeight(input.heightFeetTall, input.heightInchesTall);

            switch (input.age)
            {
                //Male calc
                case 0:
                    double calorieIntakeMale = input.bodyWeight * 4.5 + height - 5 * input.age + 5;
                    return calorieIntakeMale;
                //Female calc
                case 1:
                    double calorieIntakeFemale = input.bodyWeight;
                    return calorieIntakeFemale;
                default:
                    return 0;
            }
        }

        public int getTotalHeight (int heightFeet, int heightInches)
        {
            int heightFeetToInches = heightFeet * 12;

            int totalHeight = heightFeetToInches + heightInches;

            return totalHeight;
        }
    }
}
