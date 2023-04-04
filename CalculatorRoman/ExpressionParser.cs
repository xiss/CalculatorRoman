using Sprache;
using System.Linq.Expressions;

namespace CalculatorRoman;

internal static class ExpressionParser
{
    /// <summary>
    /// Returns an expression assembled from the source string.
    /// </summary>
    /// <param name="input">Input expression</param>
    internal static Expression<Func<Constant>> ParseExpression(string input) =>
        (Expression<Func<Constant>>)Lambda.Parse(input);

    private static readonly Parser<Expression> Constant =
        from constant in Parse.Letter.AtLeastOnce().Text()
        select Expression.Constant(new Constant(constant));

    private static Parser<ExpressionType> Operator(string op, ExpressionType opType) =>
        Parse.String(op).Return(opType);

    private static readonly Parser<ExpressionType> Add = Operator("+", ExpressionType.AddChecked);
    private static readonly Parser<ExpressionType> Subtract = Operator("-", ExpressionType.SubtractChecked);
    private static readonly Parser<ExpressionType> Multiply = Operator("*", ExpressionType.MultiplyChecked);
    private static readonly Parser<ExpressionType> Divide = Operator("/", ExpressionType.Divide);

    private static readonly Parser<Expression> ExpressionInParentheses =
        from left in Parse.Char('(')
        from expression in ExpressionAddOrSub
        from right in Parse.Char(')')
        select expression;

    private static readonly Parser<Expression> ExpressionExprOrConst = ExpressionInParentheses.Or(Constant);

    private static readonly Parser<Expression> ExpressionMultOrDiv =
        Parse.ChainOperator(Multiply.Or(Divide), ExpressionExprOrConst, Expression.MakeBinary);

    private static readonly Parser<Expression> ExpressionAddOrSub =
        Parse.ChainOperator(Add.Or(Subtract), ExpressionMultOrDiv, Expression.MakeBinary);

    private static readonly Parser<LambdaExpression> Lambda =
        ExpressionAddOrSub.Select(body => Expression.Lambda<Func<Constant>>(body));
}