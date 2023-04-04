using System.Text.RegularExpressions;
using CalculatorRoman.Exceptions;
using Sprache;

namespace CalculatorRoman;

public class Calculator
{
    /// <summary>
    /// Evaluates the expression passed to the input. Only Roman numerals.
    /// You can use the operations of division, multiplication, addition, subtraction.
    /// Supports brackets.
    /// </summary>
    /// <param name="input">Expression to evaluate.</param>
    /// <returns>Result in roman numbers</returns>
    /// <exception cref="ExpressionException"></exception>
    /// <exception cref="Exceptions.ArgumentException"></exception>
    public string Evaluate(string input)
    {
        string result;
        var regex = new Regex($"\\s");
        try
        {
            result = ExpressionParser
                .ParseExpression(regex.Replace(input, string.Empty))
                .Compile()
                .Invoke()
                .RomanNumber;
        }
        catch (ParseException e)
        {
            throw new ExpressionException(
                $"Error in expression, see internal exception: {input}", e);
        }

        return result;
    }
}