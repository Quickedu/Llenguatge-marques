using System.Data.SqlTypes;

namespace desserializer1;
public class Factures{
    public List <Factura> factures {get;set;}
}
public class Factura {
    public int id_factura {get;set;}
    public string data {get;set;}
    public Client client {get;set;}
    public float total {get;set;}
    public List <Linies_Factura> linies_factura {get;set;}
}
public class Client{
    public int id_client {get;set;}
    public string nom {get;set;}
    public string adreca {get;set;}

}
public class Linies_Factura{
    public int id_linia {get;set;}
    public string descripcio {get;set;}
    public int quantitat {get;set;}
    public float preu_unitari {get;set;}
    public float total_linia {get;set;}
}