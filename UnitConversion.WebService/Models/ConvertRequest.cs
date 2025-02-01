namespace UnitConversion.WebService.Models;

/// <summary>
/// Represents a request to convert a value from one unit to another.
/// </summary>
/// <typeparam name="TUnit">The type of the unit, which must be an enumeration.</typeparam>
public class ConvertRequest<TUnit> where TUnit : Enum
{
    /// <summary>
    /// Gets or sets the unit to convert from.
    /// </summary>
    public TUnit FromUnit { get; set; }

    /// <summary>
    /// Gets or sets the unit to convert to.
    /// </summary>
    public TUnit ToUnit { get; set; }

    /// <summary>
    /// Gets or sets the value to be converted.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertRequest{TUnit}"/> class.
    /// </summary>
    /// <param name="fromUnit">The unit to convert from.</param>
    /// <param name="toUnit">The unit to convert to.</param>
    /// <param name="value">The value to be converted.</param>
    public ConvertRequest(TUnit fromUnit, TUnit toUnit, double value)
    {
        FromUnit = fromUnit;
        ToUnit = toUnit;
        Value = value;
    }
}
