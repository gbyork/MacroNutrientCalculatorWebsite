namespace MacroNutrientCalculatorV2.Models
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }

    public class ServiceResult<T> :ServiceResult
    {
        public T Data { get; set; }
    }

}
