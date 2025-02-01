namespace UnitConversion.WebService.Models;

public class ConvertRequest<TUnit> where TUnit : Enum
{
    public TUnit FromUnit { get; set; }
    public TUnit ToUnit { get; set; }
    public double Value { get; set; }

    public ConvertRequest(TUnit fromUnit, TUnit toUnit, double value)
    {
        FromUnit = fromUnit;
        ToUnit = toUnit;
        Value = value;
    }
}
