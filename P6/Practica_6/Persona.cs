using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace p6;
public class Persona {
    [XmlAttribute("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Nom")]
    [XmlElement("Nom")]
    public string NomCognoms {get;set;}

    [XmlElement("Edat")]
    public int Edat { get; set; }

    [XmlArray("Mascotes")]
    [XmlArrayItem("Mascota")]
    public List<Mascota> Mascotes { get; set; } = new();
}