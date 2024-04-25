using Ct145_AnimacePohyb.Models;

namespace Ct145_AnimacePohyb.Pages
{
    public partial class AnimaceV2
    {
        public List<Models.Postava> Postavy { get; set; } = new List<Models.Postava>();
        protected override void OnInitialized()
        {
            base.OnInitialized();
            InicializaceHry();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Run(PrichodPostav);
                StateHasChanged();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        private void InicializaceHry()
        {
            var postava = new Models.Postava(jmeno: "Maxipes", obrazek: "../img/maxipes.png", width: 150);
            postava.PridejPozici(pozX: 45, pozY: 280, velikostObrazku: 70);
            postava.PridejPozici(pozX: 450, pozY: 240, velikostObrazku: 40);
            postava.PridejPozici(pozX: 840, pozY: 340, velikostObrazku: 80);
            postava.PridejPozici(pozX: 110, pozY: 470, velikostObrazku: 100);

            Postavy.Add(postava);

            var rnd = new Random();
            for (int i = 0; i < rnd.Next(6, 13); i++)
            {
                postava = new Models.Postava(jmeno: $"Krtek {i}", obrazek: "../img/krtek.png", width: 100);
                for (int j = 0; j < rnd.Next(3, 11); j++)
                {
                    postava.PridejPozici(pozX: rnd.Next(10,890), pozY: rnd.Next(240, 470), velikostObrazku: 100);
                }
                Postavy.Add(postava);
            }

        }

        private void PrichodPostav()
        {
            foreach (var item in Postavy)
            {
                item.Presun();
            }
        }
    }
}
