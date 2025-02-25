# JsonYamlConverterApi

This project is a simple REST API for converting JSON to YAML and vice versa. It provides endpoints to handle conversion requests and returns the converted data.

## Project Structure

- **Controllers**
  - `ConvertController.cs`: Contains methods for converting JSON to YAML and YAML to JSON.
  
- **Models**
  - `ConversionRequest.cs`: Defines the request model for conversion, including input data and conversion type.

- **Program.cs**: The entry point of the application.

- **Startup.cs**: Configures services and the request pipeline.

- **appsettings.json**: Contains configuration settings for the application.

## Endpoints

### Convert JSON to YAML

- **URL**: `/api/convert/json-to-yaml`
- **Method**: `POST`
- **Request Body**: 
  ```json
  {
    "InputData": "{ \"key\": \"value\" }",
    "ConversionType": "JsonToYaml"
  }
  ```
- **Response**: Returns the converted YAML data.

### Convert YAML to JSON

- **URL**: `/api/convert/yaml-to-json`
- **Method**: `POST`
- **Request Body**: 
  ```json
  {
    "InputData": "key: value",
    "ConversionType": "YamlToJson"
  }
  ```
- **Response**: Returns the converted JSON data.

## Technologies Used

- C#
- ASP.NET Core
- Newtonsoft.Json for JSON handling
- YamlDotNet for YAML handling

## Setup

1. Clone the repository.
2. Navigate to the project directory.
3. Run the application using the command: `dotnet run`.
4. Use a tool like Postman to test the API endpoints.