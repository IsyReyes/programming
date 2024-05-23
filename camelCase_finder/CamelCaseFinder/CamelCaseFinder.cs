using System;
using System.IO;
using System.Text.RegularExpressions;

public class CamelCaseFinder{

    public static void Parser(){
        string sourceDirectory = @"z:\programming\camelCase_finder\CamelCaseFinder";

        if(!Directory.Exists(sourceDirectory)){
            Console.WriteLine($"{sourceDirectory} does not exist");
            return;
        }else{
            Console.WriteLine($"{sourceDirectory} does exist");
        }

        var regexCamelCase = new Regex(@"\b[a-z]+([A-Z][a-z]*)+\b");

        foreach(var file in Directory.GetFiles(sourceDirectory, "*.cs", SearchOption.AllDirectories)){
            Console.WriteLine($"Scanning file {file}");

            var content = File.ReadAllText(file);
            var matches = regexCamelCase.Matches(content);

            if (matches.Count > 0){
                Console.WriteLine($"Found {matches.Count} camelCase matches in {file}:");

                foreach (Match match in matches){
                    Console.WriteLine($"   -  {match.Value} at position {match.Index}");
                }
            }else{
                Console.WriteLine("No camelCase matches found");
            }
        }
    }




}
