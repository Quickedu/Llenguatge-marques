using System.Xml.Serialization;
namespace p6;
[XmlRoot("Persona")]
class Programa {
    private static bool fi = false;
    static void Main(string[] args) {
        Operacio operacio = new();
        var persona = operacio.GetPersonaFromRandom();
        string fitxer = "persona";
        while (!fi) {
            Console.WriteLine("Indica quina operació vols fer \n0) Sortir \n1) Desar persona com XML \n2) Desar persona com JSON \n3) Llegir persona des d'XML \n4) Llegir persona des de JSON \n5) Definir nom de fitxer \n9) Pintar dades");
            var input = Console.ReadLine();
            try {
                switch (input) {
                    case "0":
                        fi = true;
                        break;
                    case "1":
                        operacio.DesarPersonaAsXml(fitxer, persona);
                        break;
                    case "2":
                        operacio.DesarPersonaAsJson(fitxer, persona);
                        break;
                    case "3":
                        Console.WriteLine("Indica el nom del fitxer: ");
                        fitxer = Console.ReadLine();
                        persona = operacio.GetPersonaFromXml($"{fitxer}.xml");
                        Console.WriteLine("Persona carregada des d'XML.");
                        break;
                    case "4":
                        Console.WriteLine("Indica el nom del fitxer: ");
                        fitxer = Console.ReadLine();
                        persona = operacio.GetPersonaFromJson($"{fitxer}.json");
                        Console.WriteLine("Persona carregada des de JSON.");
                        break;
                    case "5":
                        Console.WriteLine("Indica el nom del fitxer (sense extensió): ");
                        fitxer = Console.ReadLine();
                        break;
                    case "9":
                        operacio.PintaPersonaPerConsola(persona);
                        break;
                    default:
                        Console.WriteLine("Opció no vàlida!");
                        break;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("Sortint...");
    }
}