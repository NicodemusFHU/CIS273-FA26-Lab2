using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace BalancedParentheses;

public class Program
{
    static void Main(string[] args)
    {
    }
    
    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (var character in s)
        {
            if (character == '{' || character == '(' || character == '[' || character == '<')
            {
                stack.Push(character);
            }


            if (character == '}' || character == ')' || character == ']' || character == '>')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char mostRecentSymbol = stack.Pop();
                if (!Matches(mostRecentSymbol, character))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    public static bool Matches(char open, char close)
    {
        return (open == '{' && close == '}') ||
           (open == '(' && close == ')') ||
           (open == '[' && close == ']') ||
           (open == '<' && close == '>');
    }
}

