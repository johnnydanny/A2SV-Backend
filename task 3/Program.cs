using System;

class PalindromeChecker
{
    bool Check(string input, int left, int right)
    {
        if (left >= right)
            return true;
        else if (input[left] != input[right])
            return false;
        return Check(input, left + 1, right - 1);
    }

    void ReadInput()
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
        {
            string result = string.Empty;
            foreach (char c in input)
            {
                if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
                {
                    result += char.ToLower(c);
                }
            }

            if (result.Length > 0 && Check(result, 0, result.Length - 1))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
        else
        {
            Console.WriteLine("Input is not valid");
        }
    }

    static void Main()
    {
        PalindromeChecker checker = new PalindromeChecker();
        checker.ReadInput();
    }
}
