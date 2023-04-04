using CalculatorRoman.Exceptions;
using ArgumentException = CalculatorRoman.Exceptions.ArgumentException;

namespace CalculatorRoman.Tests;

public class ConverterTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(12, "XII")]
    [InlineData(13, "XIII")]
    [InlineData(14, "XIV")]
    [InlineData(15, "XV")]
    [InlineData(16, "XVI")]
    [InlineData(17, "XVII")]
    [InlineData(18, "XVIII")]
    [InlineData(19, "XIX")]
    [InlineData(20, "XX")]
    [InlineData(30, "XXX")]
    [InlineData(40, "XL")]
    [InlineData(50, "L")]
    [InlineData(60, "LX")]
    [InlineData(70, "LXX")]
    [InlineData(80, "LXXX")]
    [InlineData(90, "XC")]
    [InlineData(100, "C")]
    [InlineData(200, "CC")]
    [InlineData(300, "CCC")]
    [InlineData(400, "CD")]
    [InlineData(500, "D")]
    [InlineData(600, "DC")]
    [InlineData(700, "DCC")]
    [InlineData(800, "DCCC")]
    [InlineData(900, "CM")]
    [InlineData(1000, "M")]
    [InlineData(2000, "MM")]
    [InlineData(3000, "MMM")]
    [InlineData(3999, "MMMCMXCIX")]

    public void ToRoman_ValidInput_Valid(int input, string expectation)
    {
        // Act
        var result = Converter.ToRoman(input);

        // Assert
        Assert.Equal(expectation, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(0)]
    [InlineData(4000)]
    [InlineData(10000)]
    public void ToRoman_InvalidInput_Exception(int input)
    {
        // Act
        string TestFunc() => Converter.ToRoman(input);

        // Assert
        Assert.Throws<ArgumentException>(TestFunc);
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("II", 2)]
    [InlineData("III", 3)]
    [InlineData("IV", 4)]
    [InlineData("V", 5)]
    [InlineData("VI", 6)]
    [InlineData("VII", 7)]
    [InlineData("VIII", 8)]
    [InlineData("IX", 9)]
    [InlineData("X", 10)]
    [InlineData("XI", 11)]
    [InlineData("XII", 12)]
    [InlineData("XIII", 13)]
    [InlineData("XIV", 14)]
    [InlineData("XV", 15)]
    [InlineData("XVI", 16)]
    [InlineData("XVII", 17)]
    [InlineData("XVIII", 18)]
    [InlineData("XIX", 19)]
    [InlineData("XX", 20)]
    [InlineData("XXX", 30)]
    [InlineData("XL", 40)]
    [InlineData("L", 50)]
    [InlineData("LX", 60)]
    [InlineData("LXX", 70)]
    [InlineData("LXXX", 80)]
    [InlineData("XC", 90)]
    [InlineData("C", 100)]
    [InlineData("CC", 200)]
    [InlineData("CCC", 300)]
    [InlineData("CD", 400)]
    [InlineData("D", 500)]
    [InlineData("DC", 600)]
    [InlineData("DCC", 700)]
    [InlineData("DCCC", 800)]
    [InlineData("CM", 900)]
    [InlineData("M", 1000)]
    [InlineData("MM", 2000)]
    [InlineData("MMM", 3000)]
    [InlineData("MMMCMXCIX", 3999)]

    public void ToArabic_ValidInput_Valid(string input, int expectation)
    {
        // Act
        var result = Converter.ToArabic(input);

        // Assert
        Assert.Equal(expectation, result);
    }


    [Theory]
    [InlineData("IIII")]
    [InlineData("VVVV")]
    [InlineData("XXXX")]
    [InlineData("LLLL")]
    [InlineData("CCCC")]
    [InlineData("DDDD")]
    [InlineData("MMMM")]

    public void ToArabic_InvalidInput_Exception(string input)
    {
        // Act
        int TestFunc() => Converter.ToArabic(input);

        // Assert
        Assert.Throws<ArgumentException>(() => TestFunc());
    }
}