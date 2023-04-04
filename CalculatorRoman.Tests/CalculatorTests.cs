using CalculatorRoman.Exceptions;
using ArgumentException = CalculatorRoman.Exceptions.ArgumentException;

namespace CalculatorRoman.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator = new();

    [Theory]
    [InlineData("I+II+II+I", "VI")]
    [InlineData("I+I", "II")]
    [InlineData("X+II", "XII")]
    [InlineData("IIX+II", "XII")]
    public void Evaluate_Addition_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("IV-II-I", "I")]
    [InlineData("II-I", "I")]
    [InlineData("XX-I", "XIX")]
    [InlineData("X-V", "V")]

    public void Evaluate_Subtraction_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("I*I", "I")]
    [InlineData("X*X", "C")]
    [InlineData("VI*VI", "XXXVI")]
    [InlineData("XXV*XXV", "DCXXV")]
    public void Evaluate_Multiplication_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("VI/II", "III")]
    [InlineData("I/I", "I")]
    [InlineData("C/X", "X")]
    [InlineData("MM/X", "CC")]
    public void Evaluate_Division_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("(II+II)*III", "XII")]
    [InlineData("III*(II+II)", "XII")]
    [InlineData("(II*III)+III", "IX")]
    [InlineData("(II*III+II+(VI/II))+III", "XIV")]
    [InlineData("(II*III+II+(VI/II)+X)+III", "XXIV")]
    [InlineData("(MMMDCCXXIV-MMCCXXIX)*II", "MMCMXC")]
    public void Evaluate_Parenthesis_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("I+II+III+IV+V+VI+VII", "XXVIII")]
    [InlineData("(I+II+III+IV+V+VI+VII)", "XXVIII")]
    [InlineData("(I+II+III+IV+V+VI+VII)*II", "LVI")]
    [InlineData("(I+II+III+IV+V+VI+VII)*(I+II+III+IV+V+VI+VII)", "DCCLXXXIV")]
    public void Evaluate_LongExpressions_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("III*III+VI/II-I", "XI")]
    [InlineData("II+II*III", "VIII")]
    [InlineData("III+IV/II", "V")]
    [InlineData("II*III-II", "IV")]
    [InlineData("XX/II-II", "VIII")]
    public void Evaluate_OrderOfOperators_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData(" I ", "I")]
    [InlineData("I + I", "II")]
    [InlineData(" ( II-I ) ", "I")]
    [InlineData(" I     +     I", "II")]
    public void Evaluate_Whitespaces_Valid(string input, string expectation)
    {
        // Act
        var result = _calculator.Evaluate(input);
        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("1+1")]
    public void Evaluate_InvalidExpression_Exception(string input)
    {
        // Act
        string TestFunc ()=> _calculator.Evaluate(input);
        // Assert
        Assert.Throws<ExpressionException>(TestFunc);
    }

    [Theory]
    
    [InlineData("F+F")]
    [InlineData("IIII+IIII")]
    [InlineData("MMM*MMM")]
    [InlineData("I-II")]
    public void Evaluate_ImpossibleRomanArguments_Exception(string input)
    {
        // Act
        string TestFunc() => _calculator.Evaluate(input);
        // Assert
        Assert.Throws<ArgumentException>(TestFunc);
    }
}