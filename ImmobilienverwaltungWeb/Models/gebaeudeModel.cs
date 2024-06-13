namespace ImmobilienverwaltungWeb.Models
{
    public class Gebaeude
    {
        public int GebaeudeId { get; set; }
        public string Adresse { get; set; }
        public string Stadt { get; set; }
        public string PLZ { get; set; }
        public int Baujahr { get; set; }
        public decimal Preis { get; set; }
    }
}