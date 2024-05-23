using System;
using System.IO;
using System.Text.RegularExpressions;

public class CamelCaseFinder{

    public static void Parser(){
        string sourceDirectory = @"z:\programming\camelCaseFinder\CamelCaseFinder";

        if(!Directory.Exists(sourceDirectory)){
            Console.WriteLine($"{sourceDirectory} does not exist");
            return;
        }else{
            Console.WriteLine($"{sourceDirectory} does exist");
        }

        var regexCamelCase = new Regex(@"\b[a-z]+([A-Z][a-z]*)+\b");
        var regex_snake_case = new Regex(@"\b[a-z]+(_[a-z]+)*\b");

        foreach(var file in Directory.GetFiles(sourceDirectory, "*.cs", SearchOption.AllDirectories)){
            Console.WriteLine($"Scanning file {file}");

            var content = File.ReadAllText(file);
            var camelCaseMatches = regexCamelCase.Matches(content);
            var snake_case_matches = regex_snake_case.Matches(content);

            
            Console.WriteLine($"Found {camelCaseMatches.Count} camelCase matches in {file}:");

            foreach (Match match in camelCaseMatches){
                string original = match.Value;
                string converted = CaseConverter.CamelToSnake(original);
                Console.WriteLine($"   -  {original} --> {converted}");
                content = content.Replace(original, converted);
            }

        Console.WriteLine($"Found {snake_case_matches.Count} snake_case matches in {file}:");
        foreach (Match match in snake_case_matches)
            {
                string original = match.Value;
                string converted = CaseConverter.SnakeToCamel(original);
                Console.WriteLine($"  - {original} -> {converted}");
                content = content.Replace(original, converted);
            }

            File.WriteAllText(file, content);
            Console.WriteLine($"Updated {file}");
        }
    }
}

