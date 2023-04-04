namespace CalculatorRoman.Exceptions;

public class ArgumentException : Exception
{
    public ArgumentException()
    {
    }

    public ArgumentException(string message) : base(message)
    {
    }

    public ArgumentException(string message, Exception inner) : base(message, inner)
    {
    }
}