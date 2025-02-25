using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace JsonYamlConverterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertController : ControllerBase
    {
        [HttpPost("json-to-yaml")]
        public IActionResult ConvertJsonToYaml([FromBody] ConversionRequest request)
        {
            if (request.ConversionType != ConversionType.JsonToYaml)
            {
                return BadRequest("Invalid conversion type.");
            }

            try
            {
                var deserializer = new Deserializer();
                var yaml = deserializer.Deserialize<object>(request.InputData);
                var serializer = new Serializer();
                var yamlOutput = serializer.Serialize(yaml);
                return Ok(yamlOutput);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error converting JSON to YAML: {ex.Message}");
            }
        }

        [HttpPost("yaml-to-json")]
        public IActionResult ConvertYamlToJson([FromBody] ConversionRequest request)
        {
            if (request.ConversionType != ConversionType.YamlToJson)
            {
                return BadRequest("Invalid conversion type.");
            }

            try
            {
                var deserializer = new Deserializer();
                var yamlObject = deserializer.Deserialize<object>(request.InputData);
                var jsonOutput = JsonConvert.SerializeObject(yamlObject, Formatting.Indented);
                return Ok(jsonOutput);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error converting YAML to JSON: {ex.Message}");
            }
        }
    }
}