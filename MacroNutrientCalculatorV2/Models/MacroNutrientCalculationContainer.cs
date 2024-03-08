namespace MacroNutrientCalculatorV2.Models
{
    public sealed class MacroNutrientCalculationContainer
    {
        public int heightFeetTall { get; set; }
        public int heightInchesTall { get; set; }
        public double bodyWeight { get; set; }
        public int age {  get; set; }
        public int gender { get; set; }
       // public byte goal {  get; set; }
       // public byte workoutFrequency {  get; set; }
        public int carbPercentage {  get; set; }
        public int fatPercentage {  get; set; }
        public int proteinPercentage { get; set; }
    }
}
