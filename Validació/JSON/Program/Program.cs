using Json.Schema;
using System.Text.Json;
public class Program {
    public static void Main() {
        string jsonPath = "Students.json";
        string schemaPath = "Validation.json";
        if (ValidateJson(jsonPath, schemaPath)) {
            Console.WriteLine("✅ El JSON és vàlid segons l'esquema JSON Schema.");
        } else {
            Console.WriteLine("❌ El JSON no és vàlid. Revisa els errors.");
        }
    }
    public static bool ValidateJson(string jsonPath, string schemaPath) {
        bool isValid = true;
        try {
            string jsonText = File.ReadAllText(jsonPath);
            string schemaText = File.ReadAllText(schemaPath);
            JsonSchema JsonSchema = JsonSchema.FromText(schemaText);
            JsonDocument jsonDocument = JsonDocument.Parse(jsonText);
            var result = JsonSchema.Evaluate(jsonDocument.RootElement);
            if (!result.IsValid){
                isValid = false;
                Console.WriteLine("[ERRORS DE VALIDACIÓ]");
            }

        } catch (FileNotFoundException e) {
            Console.WriteLine("❌ No s'ha trobat el fitxer: " + e.FileName);
            isValid = false;
        } catch (Exception e) {
            Console.WriteLine("❌ Error inesperat: " + e.Message);
            isValid = false;
        }
        return isValid;
    }
}