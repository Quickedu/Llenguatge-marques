using System.Xml.Serialization;
using System.Collections.Generic;
namespace p6;
public class Mascota{
    [XmlAttribute("Nom")]
    public string Nom { get; set; } = default!;

    [XmlElement("Tipus")]
    public string Tipus { get; set; } = default!;
}