using System.Runtime.CompilerServices;
using System.Timers;
using System.Xml.Linq;
/*IMPORTANT, EL GUARDAD DE DOCUMENTS ESTA NOMÉS FET PER GUARDAR DOCUMENTS AMB NOM Student.xml i Students.xml (accepta ambdos noms), ja que ho guarda directament a la carpeta XMLfiles.
Com que encara no se fer que automaticament s'actualitzi el .csproj per poder indicar la ruta de l'arxiu, no puc fer que el nom sigui el que es vulgui */
public class Program{
    private static int total;
    private static bool fitxercorrecte = false;
    private static bool fitxercarregat = false;
    private static string nom;
    private static int edat;
    private static string curs;
    private static string fitxer;
    private static string url;
    private static string input;
    private static XDocument doc;
    private static int totalnotes = 0;
    private static int dividendo;
    private static int jj = 0;
    private static List <double> nota = new();
    public static void Main (){
        while (true){
            Console.WriteLine("Disposes de fitxer XML? (Y/N)");
            fitxer = Console.ReadLine().ToUpper();
            if (fitxer == "Y" || fitxer == "N")break;
        }
        if (fitxer == "N"){
            crearxml();
            fitxer = $"XMLfiles/{url}.xml";
        }
        while (!fitxercorrecte){ 
            if (fitxer == "Y"){
                Console.WriteLine("Indica el nom del fitxer sense extensio");
                fitxer = $"XMLfiles/{Console.ReadLine()}.xml";
            }
            try{
                doc = XDocument.Load(fitxer);
                fitxercorrecte = true;
            }  catch (FileNotFoundException) {
                Console.WriteLine("Document path no trobat. Torna a introduir el nom del document");
                continue;
            }
        }
        while (true){
            while (!fitxercarregat){
                Console.WriteLine("Fitxer carregat! \n Indica que vols fer amb el fitxer \n - Mostrar el document sencer (M) \n - Calcular nota mitjana de cada estudiant (N) \n - Afegir nou estudiant (A) \n - Actualitzar la nota més baixa d'un estudiant (B) \n - Esborrar un estudiant (D)");
                input = Console.ReadLine().ToUpper();
                if (input != "M" && input != "N" && input != "A" && input != "B" && input != "D" ){ 
                Console.WriteLine("Valor introduit incorrecte! Torna a introduir el valor \n");
                continue;
                }
                break;
            }
            switch (input){
                case "A":
                afegirestudiant(doc);
                break;
                case "M":
                docsencer(doc);
                break;
                case "N":
                calculnota(doc);
                break;
                case "D":
                delete(doc);
                break;
                case "B":
                actualitzar(doc);
                break;
            }   
        }
    }
    private static void crearxml(){
        Console.WriteLine("Quin nom vols que tingui el teu arxiu? (l'extensio s'hi afegira automaticament)");
        url = Console.ReadLine();
        while (true){
        Console.WriteLine("Quants alumnes vols crear?");
        if (int.TryParse(Console.ReadLine(), out total)) break;
        Console.WriteLine("Introdueix un numero valid.\n \n");
        }
        Console.WriteLine($"S'esta creant el nou alumne. A continuacio, hauras d'introduir les dades dels {total} alumnes que has indicat a crear.");
        XElement Students = new XElement("Students");

        for (int i = 0; i < total; i++){
            Console.WriteLine("NOM");
            nom = Console.ReadLine();
            Console.WriteLine("EDAT");
            edat = int.Parse(Console.ReadLine());
            Console.WriteLine("CURS");
            curs = Console.ReadLine();
            Console.WriteLine("Quantes notes te aquest alumne?");
            var numalumnes = int.Parse(Console.ReadLine());
            for (int j=0; j<numalumnes;j++){
                Console.WriteLine($"Nota {j+1}");
                nota.Add(double.Parse(Console.ReadLine()));
            }

            XElement Student = new XElement("Student",
                new XAttribute("id", i+1),
                new XElement("Nom", nom),
                new XElement("Edat", edat),
                new XElement("Curs", curs),
                new XElement("Notes")
            );

            foreach (var notes in nota)
            {
                jj++;   
                Student.Element("Notes").Add(new XElement($"Nota{jj}", notes));
            }
            nota.Clear();
            jj=0;

            Students.Add(Student);
            if (i<total-1){
                Console.WriteLine("\n -------------- SEGUENT ALUMNE ----------------- \n ");
            }
        }

        Students.Save($"XMLfiles/{url}.xml");
    }
    public static void afegirestudiant(XDocument doc){
        Console.WriteLine("NOM");
            nom = Console.ReadLine();
            Console.WriteLine("EDAT");
            edat = int.Parse(Console.ReadLine());
            Console.WriteLine("CURS");
            curs = Console.ReadLine();
            Console.WriteLine("Quantes notes te aquest alumne?");
            var numalumnes = int.Parse(Console.ReadLine());
            for (int j=0; j<numalumnes;j++){
                Console.WriteLine($"Nota {j+1}");
                nota.Add(double.Parse(Console.ReadLine()));
            }
            var maxId = doc.Descendants("Student").Max(x => (int)x.Attribute("id"));
            var newId = maxId + 1;

            XElement Student = new XElement("Student",
                new XAttribute("id", newId),
                new XElement("Nom", nom),
                new XElement("Edat", edat),
                new XElement("Curs", curs),
                new XElement("Notes")
            );

            foreach (var notes in nota)
            {
                jj++;   
                Student.Element("Notes").Add(new XElement($"Nota{jj}", notes));
            }
            nota.Clear();
            jj=0;

            doc.Root.Add(Student);
            doc.Save(fitxer);
            Console.WriteLine("Estudiant afegit correctament i guardat a l'arxiu.");
    }
    public static void docsencer(XDocument doc){
        foreach (var alumne in doc.Descendants("Student")){
            Console.WriteLine($"Id alumne: {alumne.Attribute("id").Value} \n - Nom alumne: {alumne.Element("Nom").Value} \n - Edat alumne: {alumne.Element("Edat").Value} \n - Curs alumne: {alumne.Element("Curs").Value} \n - Notes alumne:");
            var notes = alumne.Element("Notes").Elements();
            jj=0;
            foreach (var nota in notes){
                jj++;
                Console.WriteLine($"    - Nota {jj}: {nota.Value}");
            }
            Console.WriteLine("\n ---------------------------- \n SEGUENT ALUMNE \n");
        }
        Console.WriteLine("\n ---------------- FINAL DE DOCUMENT -----------------");
    }
    public static void calculnota(XDocument doc){
        foreach(var alumne in doc.Descendants("Student")){
            totalnotes=0;
            dividendo=0;
            var notes = alumne.Element("Notes").Elements();
            foreach (var nota in notes){
                totalnotes += int.Parse(nota.Value);
                dividendo ++;
            }
            totalnotes = totalnotes/dividendo;
            Console.WriteLine($"Alumne: {alumne.Element("Nom").Value} \nNota mitja: {totalnotes} \n");
            Console.WriteLine($"--------------Fi de linia--------------");
        }
    }
    public static void delete(XDocument doc){
        Console.WriteLine("Introdueix l'id de l'estudiant");
        var id = Console.ReadLine();
        foreach(var alumne in doc.Descendants("Student")){
            if (alumne.Attribute("id").Value==id){
                alumne.Remove();
                doc.Save(fitxer);
                return;
            }
        }
        Console.WriteLine("No has introduit un id valid");
    }
    public static void actualitzar(XDocument doc){
        Console.WriteLine("Introdueix l'id de l'estudiant a actualitzar nota");
        var id = Console.ReadLine();
        var mespetita = 11;
        var peque = 0;
        List <int> notetes = new();
        foreach (var alumne in doc.Descendants("Student")){
            if (alumne.Attribute("id").Value==id){
                var notes = alumne.Element("Notes").Elements();
                foreach (var nota in notes){
                    notetes.Add(int.Parse(nota.Value));
                }
                for (int i = 0; i<notes.Count(); i++){
                    if (notetes[i]<mespetita){
                        mespetita = notetes[i];
                        peque = i;
                    }
                }
                Console.WriteLine("Introdueix la nota nova");
                var notacanviada = int.Parse(Console.ReadLine());
                notes.ElementAt(peque).Value = notacanviada.ToString();
                doc.Save(fitxer);
                Console.WriteLine("Nota actualitzada correctament i guardada a l'arxiu.");
                return;
            }
        }
        Console.WriteLine("No has introduit un id valid");
    }
}