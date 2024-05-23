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
    }

    

}
