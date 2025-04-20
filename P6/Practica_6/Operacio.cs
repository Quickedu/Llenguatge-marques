using System.Text.Json;
using System.Xml.Serialization;

namespace p6;
public class Operacio : IOperacio {
    private static Random random = new Random();
    private static string nom = "";

    public void DesarPersonaAsJson(string fitxer, Persona persona) {
        string json = JsonSerializer.Serialize(persona, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($"{fitxer}.json", json);
        Console.WriteLine($"Persona desada com JSON a {fitxer}.json");
    }

    public void DesarPersonaAsXml(string fitxer, Persona persona) {
        XmlSerializer serializer = new(typeof(Persona));
        using (FileStream fs = new($"{fitxer}.xml", FileMode.Create)) {
            serializer.Serialize(fs, persona);
        }
        Console.WriteLine($"Persona desada com XML a {fitxer}.xml");
    }

    public Persona GetPersonaFromJson(string fitxer) {
        if (!File.Exists(fitxer)) {
            throw new FileNotFoundException($"El fitxer {fitxer} no existeix.");
        }
        string json = File.ReadAllText(fitxer);
        var personaDeserialitzada = JsonSerializer.Deserialize<Persona>(json) ?? throw new InvalidOperationException("Error en deserialitzar el JSON.");
        Console.WriteLine($"ID: {personaDeserialitzada.Id}, Persona: {personaDeserialitzada.NomCognoms}, Edat: {personaDeserialitzada.Edat}");
        foreach (var m in personaDeserialitzada.Mascotes) {
            Console.WriteLine($" - Mascota: {m.Nom}, Tipus: {m.Tipus}");
        }
        return personaDeserialitzada;
    }

    public Persona GetPersonaFromXml(string fitxer) {
        if (!File.Exists(fitxer)) {
            throw new FileNotFoundException($"El fitxer {fitxer} no existeix.");
        }
        XmlSerializer serializer = new(typeof(Persona));
        using (FileStream fs = new(fitxer, FileMode.Open)) {
            var personaDeserialitzada = (Persona)(serializer.Deserialize(fs) ?? throw new InvalidOperationException("Error en deserialitzar l'XML."));
            Console.WriteLine($"ID: {personaDeserialitzada.Id},Persona: {personaDeserialitzada.NomCognoms}, Edat: {personaDeserialitzada.Edat}");
            foreach (var m in personaDeserialitzada.Mascotes) {
                Console.WriteLine($" - Mascota: {m.Nom}, Tipus: {m.Tipus}");
            }
            return personaDeserialitzada;
        }
    }

    public Persona GetPersonaFromRandom() {
        var nommascota = "";
        var rnd2 = random.Next(3, 9);
        for (int i = 0; i < rnd2; i++) {
            var rnd = random.Next(97, 123);
            nom += (char)rnd;
        }
        rnd2 = random.Next(3, 9);
        List<string> mascotes = new List<string> { "gat", "gos", "tortuga", "peix", "ocell" };
        for (int i = 0; i < rnd2; i++) {
            var rnd = random.Next(97, 123);
            nommascota += (char)rnd;
        }
        return new Persona {
            Id = random.Next(0, 1000),
            Edat = random.Next(0, 101),
            NomCognoms = nom,
            Mascotes = new List<Mascota> {
                new Mascota {
                    Nom = nommascota,
                    Tipus = mascotes[random.Next(0, mascotes.Count)]
                }
            }
        };
    }

    public void PintaPersonaPerConsola(Persona persona) {
        Console.WriteLine($"Persona:\nId: {persona.Id}\nNom: {persona.NomCognoms}\nEdat: {persona.Edat}");
        Console.WriteLine("Mascotes:");
        foreach (var mascota in persona.Mascotes) {
            Console.WriteLine($" - Nom: {mascota.Nom}, Tipus: {mascota.Tipus}");
        }
    }
}