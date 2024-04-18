namespace Ct145_AnimacePohyb.Models
{
    public class Postava
    {
        public Postava(string jmeno, string obrazek) 
        { 
            Jmeno = jmeno;
            Obrazek = obrazek;
            AktualniPozice = 0;
        }
        public string Jmeno { get; }
        public string Obrazek { get; }
        private int AktualniPozice { get; set; } 
        private List<Souradnice> PoziceList { get; set; } = new List<Souradnice>();
        public string Style => PoziceList[AktualniPozice].Style;
        public void PridejPozici(int pozX, int pozY, int velikostObrazku)
        {
            PoziceList.Add(new Souradnice(pozX, pozY, velikostObrazku));
        }
    }
}
