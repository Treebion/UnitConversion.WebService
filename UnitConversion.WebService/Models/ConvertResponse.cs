namespace UnitConversion.WebService.Models;

public class ConvertResponse<TUnit> where TUnit : Enum
{
    public TUnit FromUnit { get; set; }  // Source unit
    public TUnit ToUnit { get; set; }    // Target unit
    public double InputValue { get; set; }  // Original value
    public double ConvertedValue { get; set; }  // Converted result

    public ConvertResponse(TUnit fromUnit, TUnit toUnit, double inputValue, double convertedValue)
    {
        FromUnit = fromUnit;
        ToUnit = toUnit;
        InputValue = inputValue;
        ConvertedValue = convertedValue;
    }
}
