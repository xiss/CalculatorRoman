using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CalculatorRoman;

var summary = BenchmarkRunner.Run<Benchmark>();

public class Benchmark
{
    private const string TestExpression =
        "(LX+LX)*II-X/II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II-II+II";

    private readonly Calculator _calculator = new();

    [Benchmark]
    public void EvaluateExpression()
    {
        var result = _calculator.Evaluate(TestExpression);
    }
}
