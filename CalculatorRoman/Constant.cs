namespace CalculatorRoman;

internal struct Constant
{
    /// <summary>
    /// Creates a constant from a roman number.
    /// </summary>
    public Constant(string romanNumber)
    {
        ArabicNumber = Converter.ToArabic(romanNumber);
        RomanNumber = romanNumber;
    }

    /// <summary>
    /// Creates a constant from a arabic number.
    /// </summary>
    public Constant(int arabicNumber)
    {
        ArabicNumber = arabicNumber;
        RomanNumber = Converter.ToRoman(arabicNumber);
    }

    public int ArabicNumber { get; }
    public string RomanNumber { get; }

    public static Constant operator -(Constant constantLeft, Constant constantRight) =>
        new(constantLeft.ArabicNumber - constantRight.ArabicNumber);

    public static Constant operator *(Constant constantLeft, Constant constantRight) =>
        new(constantLeft.ArabicNumber * constantRight.ArabicNumber);

    public static Constant operator /(Constant constantLeft, Constant constantRight) =>
        new(constantLeft.ArabicNumber / constantRight.ArabicNumber);

    public static Constant operator +(Constant constantLeft, Constant constantRight) =>
        new(constantLeft.ArabicNumber + constantRight.ArabicNumber);
}