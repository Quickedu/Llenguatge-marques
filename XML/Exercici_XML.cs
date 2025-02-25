namespace XML;

using System.Data.Common;
using System.Xml.Linq;
public class Program{
        private int total;
        private string nom;
        private int edat;
        private string curs;
        private string fitxer;
        private string url;
        private XDocument doc;
        private List <double> nota = new();
    public void Main (){
        while (true){
        Console.WriteLine("Disposes de fitxer XML? (Y/N)");
        fitxer = Console.ReadLine();
        if (fitxer == "Y" || fitxer == "N")break;
        }
        if (fitxer == "N"){
            crearxml();
            fitxer = $"{url}.xml";
        }
        if (fitxer == "Y"){
            Console.WriteLine("Indica la ruta o nom del fitxer");
            fitxer = Console.ReadLine();
        }
        doc = XDocument.Load(fitxer);

        
        
    }
    private void crearxml(){
        Console.WriteLine("Quin nom vols que tingui el teu arxiu? (l'extensio s'hi afegira automaticament)");
        url = Console.ReadLine();
        while (true){
        Console.WriteLine("Quants alumnes vols crear?");
        if (int.TryParse(Console.ReadLine(), out total)) break;
        Console.WriteLine("Introdueix un numero valid.\n \n");
        }
        Console.WriteLine($"S'esta creant el nou alumne. A continuacio, hauras d'introduir les dades dels {total} alumnes que has indicat a crear.");
        XElement studentsElement = new XElement("Students");

        for (int i = 0; i < total; i++)
        {
            Console.WriteLine("NOM");
            nom = Console.ReadLine();
            Console.WriteLine("EDAT");
            edat = int.Parse(Console.ReadLine());
            Console.WriteLine("CURS");
            curs = Console.ReadLine();
            Console.WriteLine("Quantes notes te aquest alumne?");
            for (int j=0; j<int.Parse(Console.ReadLine());j++){
                Console.WriteLine($"Nota {i}");
                nota.Add(int.Parse(Console.ReadLine()));
            }

            XElement studentElement = new XElement("Student",
                new XAttribute("id", i),
                new XElement("Nom", nom),
                new XElement("Edat", edat),
                new XElement("Curs", curs),
                new XElement("Notes")
            );

            foreach (var notes in nota)
            {
                studentElement.Element("Notes").Add(new XElement("Nota", notes));
            }

            studentsElement.Add(studentElement);
        }

            studentsElement.Save($"{url}.xml");
    }
}