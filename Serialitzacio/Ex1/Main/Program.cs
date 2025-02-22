using System.Text.Json;
using System.Text.RegularExpressions;

namespace desserializer1;
public class Project{
    public static void Main(){
        string filename = "jason.json";
        string jsonFile = File.ReadAllText(filename);
        Factures? factures = JsonSerializer.Deserialize<Factures>(jsonFile);
        Console.WriteLine(Regex.Unescape(escriure(factures)));
    }
    public static string escriure(Factures? factures){
        var textfinal = "";
        foreach (var factura in factures.factures){
            textfinal += $"{nameof (factura.id_factura)} : {factura.id_factura} \\n";
            textfinal += $"{nameof (factura.data)} : {factura.data} \\n";
            textfinal += $"{nameof (factura.client.id_client)} : {factura.client.id_client} \\n";
            textfinal += $"{nameof (factura.client.nom)} : {factura.client.nom} \\n";
            textfinal += $"{nameof (factura.client.adreca)} : {factura.client.adreca} \\n";
            textfinal += $"{nameof (factura.total)} : {factura.total} \\n";
            textfinal += $"{nameof (factura.linies_factura)} : {factura.linies_factura} \\n";
            foreach (var liniafactura in factura.linies_factura){
                textfinal += $"{nameof (liniafactura.id_linia)} : {liniafactura.id_linia} \\n";
                textfinal += $"{nameof (liniafactura.id_linia)} : {liniafactura.descripcio} \\n";
                textfinal += $"{nameof (liniafactura.id_linia)} : {liniafactura.quantitat} \\n";
                textfinal += $"{nameof (liniafactura.id_linia)} : {liniafactura.preu_unitari} \\n";
                textfinal += $"{nameof (liniafactura.id_linia)} : {liniafactura.total_linia} \\n";
                textfinal += "\\n";
            }
        }
        return textfinal;
    }
}