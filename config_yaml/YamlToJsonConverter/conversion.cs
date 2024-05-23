using System;
using System.IO;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

class Converter{

    static void Main(string[] args){
        string yamlDirectory = @"Z:\programming\config_yaml\YamlToJsonConverter\config_yaml";
        string jsonDirectory = @"Z:\programming\config_yaml\YamlToJsonConverter\config_json";




        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var serializer = new SerializerBuilder()
            .JsonCompatible()
            .Build();

            Directory.CreateDirectory(jsonDirectory);

            Console.WriteLine("Converting YAML files from: " + yamlDirectory);


        foreach (var file in Directory.GetFiles(yamlDirectory, "*.yaml")){

            var yaml = File.ReadAllText(file);
            var yamlObject = deserializer.Deserialize(new StringReader(yaml));

            var json = JsonConvert.SerializeObject(yamlObject, Formatting.Indented);

            var jsonFileName = Path.GetFileNameWithoutExtension(file) + ".json";
            var jsonFilePath = Path.Combine(jsonDirectory, jsonFileName);

            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Converted {file} to {jsonFilePath}");
        }
    }
}