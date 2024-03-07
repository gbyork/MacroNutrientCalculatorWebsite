using MacroNutrientCalculatorV2.Models;
using Microsoft.AspNetCore.Components.Forms;

//adding this here incase I need to review microsoft documentation. https://learn.microsoft.com/aspnet/core

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
            ServiceResult result = new ServiceResult();

            double calorieIntake = calculateCalorieIntake(input);
            double carbIntake = calculateCarbIntake(calorieIntake, input);
            double fatIntake = calculateFatIntake(calorieIntake, input);
            double proteinIntake = calculateProteinIntake(calorieIntake, input);

            if (calorieIntake < 0)
            {
                result.Success = false;
                result.Message = "An error occurred in this calculation, please try again.";
            }

            if (calorieIntake > 0)
            {
                result.Success = true;
                result.Message = calorieIntake.ToString() + carbIntake.ToString() + fatIntake.ToString() + proteinIntake.ToString();
            }
            return result;
        }

        public double calculateCalorieIntake (MacroNutrientCalculationContainer input) 
        {
            double height = getTotalHeightInCentimeters(input.heightFeetTall, input.heightInchesTall);
            double weight = getWeightInKilograms(input.bodyWeight);

            switch (input.gender)
            {
                //Male calc
                case 0:
                    double calorieIntakeMale = (10 * weight * 0.45359237) + (6.25 * height) - (5 * input.age) + 5;
                    return calorieIntakeMale;
                //Female calc
                case 1:
                    double calorieIntakeFemale = (10 * weight) + (6.25 * height) - (5 * input.age) -161;
                    return calorieIntakeFemale;
                default:
                    return 0;
            }
        }

        public double getTotalHeightInCentimeters (int heightFeet, int heightInches)
        {
            int heightFeetToInches = heightFeet * 12;

            int totalHeightToInches = heightFeetToInches + heightInches;

            double totalHeightToCentimeters = totalHeightToInches * 2.54;

            return totalHeightToCentimeters;
        }

        public double getWeightInKilograms(double bodyWeightInPounds)
        {
            double bodyWeightKilograms = bodyWeightInPounds * 0.45359237;

            return bodyWeightKilograms;
        }

        public double calculateCarbIntake(double calorieIntake, MacroNutrientCalculationContainer input)
        {
            double fatIntake = calorieIntake * (0.01 * input.carbPercentage);
            return fatIntake;
        }

        public double calculateFatIntake(double calorieIntake, MacroNutrientCalculationContainer input)
        {
            double fatIntake = calorieIntake * (0.01 * input.fatPercentage);
            return fatIntake;
        }

        public double calculateProteinIntake(double calorieIntake, MacroNutrientCalculationContainer input)
        {
            double fatIntake = calorieIntake * (0.01 * input.proteinPercentage);
            return fatIntake;
        }
    }
}
