namespace Ct145_AnimacePohyb.Models
{
    public class Postava
    {
        public Postava(string jmeno, string obrazek, int width) 
        { 
            Jmeno = jmeno;
            Obrazek = obrazek;
            AktualniPozice = 0;
            Width = width;
            AktualniPozice = -1;
        }
        public string Jmeno { get; }
        public string Obrazek { get; }
        public int Width { get; set; }
        private int AktualniPozice { get; set; } 
        private List<Souradnice> PoziceList { get; set; } = new List<Souradnice>();
        private bool SmerVpred { get; set; } = true;
        public bool HlavaVpravo { get; set; } = true;
        public string Style
        {
            get
            {
                if (AktualniPozice < 0)
                    return $"width: {Width}px;";
                else
                    return PoziceList[AktualniPozice].Style + $"width: {Width}px;";
            }
        }

        public string StyleTransform => HlavaVpravo ? "transform: rotateY(0deg);" : "transform: rotateY(180deg);";

        public int Progress => PoziceList.Count - 1 <= 0 ? 100 : (int)((double)AktualniPozice / (PoziceList.Count -1) * 100);

        public void PridejPozici(int pozX, int pozY, int velikostObrazku)
        {
            PoziceList.Add(new Souradnice(pozX, pozY, velikostObrazku));
        }

        public void Presun()
        {
            if (SmerVpred)
            {
                if (AktualniPozice == PoziceList.Count - 1)
                {
                    SmerVpred = false;
                }
            }
            else
            {
                if (AktualniPozice == 0)
                {
                    SmerVpred = true;
                }
            }
            var predchoziPozice = AktualniPozice;

            if (SmerVpred) 
                AktualniPozice++;
            else
                AktualniPozice--;
            if (predchoziPozice >= 0)
            {
                HlavaVpravo = PoziceList[AktualniPozice].PozX > PoziceList[predchoziPozice].PozX;
            }
        }
    }
}
