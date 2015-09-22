namespace InterpreterPattern.Expressions
{
    internal interface IExpression
    {
        void Interpret(Context ctx);
    }
}