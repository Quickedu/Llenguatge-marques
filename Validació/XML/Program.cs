using System.Xml;
using System.Xml.Schema;

class Program
{
    private static string xmlPath = "";
    static void Main(){
        Console.WriteLine("Validar correcte (BO) o incorrecte (DOLENT) (B/D)");
        while (true){
            string input = Console.ReadLine().ToUpper();
            if (input == "B"){
            xmlPath = "Student.xml";
            break;
            } else if (input == "D"){
                xmlPath = "StudentMal.xml";
                break;
                } else {
                    Console.WriteLine("Error, torna a introduir el valor");
                }
        }
        string xsdPath = "Validacio.xsd";
        if (ValidateXml(xmlPath, xsdPath)){
            Console.WriteLine("✅ El XML es vàlid segons l'esquema XSD seguit.");
        }
        else{
            Console.WriteLine("❌ El XML no es vàlid. Revisa els errors!");
        }
    }

    public static bool ValidateXml(string xmlFilePath, string xsdFilePath){
        bool isValid = true;
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add("", xsdFilePath);
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas = schemaSet;
        settings.ValidationType = ValidationType.Schema;
        settings.ValidationEventHandler += (sender, args) => {
            isValid = false;            
            Console.WriteLine($"[ERROR] Línia {args.Exception.LineNumber}, Columna {args.Exception.LinePosition}: {args.Message}");
        };

        // Obre el fitxer XML i aplica la configuració definida anteriorment.
        using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
        {
            try
            {
                // Llegeix tot el fitxer XML per a validar-lo.
                while (reader.Read()) { }
            }
            catch (Exception ex)
            {
                // Captura qualsevol excepció durant la lectura i la mostra per consola.
                isValid = false;
                Console.WriteLine($"[EXCEPCIÓ] {ex.Message}");
            }
        }

        // Retorna true si l'XML és vàlid, o false si hi ha hagut errors.
        return isValid;
    }
}