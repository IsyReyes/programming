using System;
using System.Text.RegularExpressions;

public static class CaseConverter
{
    public static string CamelToSnake(string input)
    {
        return Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2").ToLower();
    }

    public static string SnakeToCamel(string input)
    {
        var segments = input.Split('_');
        for (int i = 1; i < segments.Length; i++)
        {
            segments[i] = Char.ToUpper(segments[i][0]) + segments[i].Substring(1);
        }
        return string.Join("", segments);
    }
}