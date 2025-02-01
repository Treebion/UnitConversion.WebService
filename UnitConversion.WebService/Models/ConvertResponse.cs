namespace UnitConversion.WebService.Models;

/// <summary>
/// Represents a response for a unit conversion operation.
/// </summary>
/// <typeparam name="TUnit">The type of the unit, which must be an enumeration.</typeparam>
public class ConvertResponse<TUnit> where TUnit : Enum
{
    /// <summary>
    /// Gets or sets the source unit.
    /// </summary>
    public TUnit FromUnit { get; set; }  // Source unit

    /// <summary>
    /// Gets or sets the target unit.
    /// </summary>
    public TUnit ToUnit { get; set; }    // Target unit

    /// <summary>
    /// Gets or sets the original value to be converted.
    /// </summary>
    public double InputValue { get; set; }  // Original value

    /// <summary>
    /// Gets or sets the converted result.
    /// </summary>
    public double ConvertedValue { get; set; }  // Converted result

    /// <summary>
    /// Initializes a new instance of the <see cref="ConvertResponse{TUnit}"/> class.
    /// </summary>
    /// <param name="fromUnit">The source unit.</param>
    /// <param name="toUnit">The target unit.</param>
    /// <param name="inputValue">The original value to be converted.</param>
    /// <param name="convertedValue">The converted result.</param>
    public ConvertResponse(TUnit fromUnit, TUnit toUnit, double inputValue, double convertedValue)
    {
        FromUnit = fromUnit;
        ToUnit = toUnit;
        InputValue = inputValue;
        ConvertedValue = convertedValue;
    }
}
