using System;
using System.Collections.Generic;

public class TextProcessor
{

    void Print(Dictionary<string, int> data)
    {
        foreach (var info in data)
        {
            Console.WriteLine($"{info.Key}:{info.Value}");
        }
    }

    string Format(string value)
    {
        string result = string.Empty;

        foreach (char val in value)
        {
            if (!char.IsPunctuation(val))
            {
                result += char.ToLower(val);
            }
        }
        return result;
    }

    void ProcessInput(string input)
    {
        string[] words = input.Split(' ');
        Dictionary<string, int> data = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (word != " ")
            {
                string result = Format(word);
                if (!string.IsNullOrEmpty(result))
                {
                    if (data.ContainsKey(result))
                    {
                        data[result] += 1;
                    }
                    else
                    {
                        data[result] = 1;
                    }
                }
            }
        }

        Print(data);
    }

    void ReadInput()
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
        {
            input = input.Trim();
            ProcessInput(input);
        }
        else
        {
            Console.WriteLine($"Input '{input}' is not valid");
        }
    }

    public static void Main()
    {
        // Start of program
        TextProcessor program = new TextProcessor();
        program.ReadInput();
    }
}


