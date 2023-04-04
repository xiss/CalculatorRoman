using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ArgumentException = CalculatorRoman.Exceptions.ArgumentException;

[assembly: InternalsVisibleTo("CalculatorRoman.Tests")]
namespace CalculatorRoman;

internal static class Converter
{
    /// <summary>
    /// Sequence of characters less than 4
    /// </summary>
    private static readonly Regex RegexSequenceLessThenFour;

    /// <summary>
    /// String contains letters only from Roman numerals
    /// </summary>
    private static readonly Regex RegexOnlyRomanNumerals;

    private static readonly Dictionary<char, int> RomanToInteger = new() {
        { 'M', 1000 },
        { 'D', 500 },
        { 'C', 100 },
        { 'L', 50 },
        { 'X', 10 },
        { 'V', 5 },
        { 'I', 1 }
    };

    static Converter()
    {
        RegexSequenceLessThenFour = new Regex(string.Join('|', RomanToInteger.Select(x => $"({x.Key}{{4,}})").ToArray()),
            RegexOptions.Compiled);

        RegexOnlyRomanNumerals = new Regex($"^[{string.Join(null, RomanToInteger.Keys)}]",
            RegexOptions.Compiled);
    }

    /// <summary>
    /// Converts roman number to arabic.
    /// </summary>
    /// <param name="input">Input roman number</param>
    /// <exception cref="ArgumentException"></exception>
    internal static int ToArabic(string input)
    {
        var result = 0;

        //Checking the sequence of characters less than 4
        if (RegexSequenceLessThenFour.IsMatch(input))
            throw new ArgumentException(
                $"Roman numerals allow numbers only 3 characters in a row: {input}");

        //Checking that the expression contains letters only from Roman numerals
        if (!RegexOnlyRomanNumerals.IsMatch(input))
            throw new ArgumentException(
                $"Roman numbers can only contain the following letters:{string.Join(' ', RomanToInteger.Keys)}" +
                $"The following expression contains an error: {input}");

        for (var i = 0; i < input.Length; i++)
        {
            var currentChar = input[i];
            var currentValue = RomanToInteger[currentChar];

            if (i + 1 < input.Length)
            {
                var nextChar = input[i + 1];
                var nextValue = RomanToInteger[nextChar];

                if (currentValue < nextValue)
                    result -= currentValue;
                else
                    result += currentValue;
            }
            else
            {
                result += currentValue;
            }
        }

        return result;
    }

    /// <summary>
    /// Converts arabic number to roman.
    /// </summary>
    /// <param name="input">Arabic number</param>
    /// <exception cref="Exceptions.ArgumentException"></exception>
    internal static string ToRoman(int input)
    {
        var result = string.Empty;
        if (input is < 1 or > 3999)
            throw new ArgumentException(
                $"Roman numerals allow numbers in the range from 1 to 3999, current value: {input}");

        while (input > 0)
        {
            switch (input)
            {
                case >= 1000:
                    result += "M"; input -= 1000; continue;
                case >= 900:
                    result += "CM"; input -= 900; continue;
                case >= 500:
                    result += "D"; input -= 500; continue;
                case >= 400:
                    result += "CD"; input -= 400; continue;
                case >= 100:
                    result += "C"; input -= 100; continue;
                case >= 90:
                    result += "XC"; input -= 90; continue;
                case >= 50:
                    result += "L"; input -= 50; continue;
                case >= 40:
                    result += "XL"; input -= 40; continue;
                case >= 10:
                    result += "X"; input -= 10; continue;
                case >= 9:
                    result += "IX"; input -= 9; continue;
                case >= 5:
                    result += "V"; input -= 5; continue;
                case >= 4:
                    result += "IV"; input -= 4; continue;
                case >= 1:
                    result += "I"; input -= 1; continue;
            }
        }

        return result;
    }
}