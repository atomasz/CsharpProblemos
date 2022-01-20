
namespace Problemos
{
    public static class Calculator
    {
        public static int Calculate(string s)
        {
            var stack = new Stack<int>();
            
            var result = 0;
            var currentNumber = 0;
            var currentSign = 1;
            
            for (var i = 0; i < s.Length; i++)
            {
                var currentChar = s[i];
                if (char.IsDigit(currentChar))
                {
                    currentNumber = currentNumber * 10 + (currentChar - '0');
                }
                else if (currentChar == ' ')
                    continue;
                else if (currentChar == '+')
                {
                    result += currentSign * currentNumber;
                    currentSign = 1;
                    currentNumber = 0;
                } else if (currentChar == '-')
                {
                    result += currentSign * currentNumber;
                    currentSign = -1;
                    currentNumber = 0;
                } else if (currentChar == '(')
                {
                    stack.Push(result);
                    stack.Push(currentSign);
                    currentSign = 1;
                    result = 0;
                } else if (currentChar == ')')
                {
                    result += currentSign * currentNumber;
                    currentNumber = 0;
                    result *= stack.Pop();
                    result += stack.Pop();
                }
            }

            result += currentNumber * currentSign;

            return result;
        }
    }
}
