public class ConversionRequest
{
    public string? InputData { get; set; } // Make InputData nullable
    public ConversionType ConversionType { get; set; }
}

public enum ConversionType
{
    JsonToYaml,
    YamlToJson
}