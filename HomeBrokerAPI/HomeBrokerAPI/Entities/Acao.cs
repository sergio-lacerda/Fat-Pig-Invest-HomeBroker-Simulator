using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBrokerAPI.Entities
{
    public class Acao
    {
        public string Ticker { get; set; }
        public Empresa Empresa { get; set; }
        public List<Oferta> Ofertas { get; set; }

        public Acao(string ticker, Empresa empresa, double valorInicial)
        {
            this.Ticker = ticker;
            this.Empresa = empresa;
            this.Ofertas = obterOfertas(valorInicial);
        }

        private List<Oferta> obterOfertas(double valorInicial)
        {
            List<Oferta> ofertas = new List<Oferta>();

            Corretora nuInvest = new Corretora(1, "NuInvest", "00.000.000/0000-00");
            Corretora modal = new Corretora(2, "Modal", "00.000.000/0000-00");
            Corretora xp = new Corretora(3, "XP Invest", "00.000.000/0000-00");
            Corretora clear = new Corretora(4, "Clear", "00.000.000/0000-00");

            ofertas.Add(new Oferta(this.Ticker, nuInvest, 'C', 1200, valorInicial - 0.01));
            ofertas.Add(new Oferta(this.Ticker, nuInvest, 'C', 300, valorInicial - 0.01));
            ofertas.Add(new Oferta(this.Ticker, modal, 'C', 100, valorInicial - 0.03));
            ofertas.Add(new Oferta(this.Ticker, clear, 'C', 600, valorInicial - 0.02));
            ofertas.Add(new Oferta(this.Ticker, xp, 'C', 1000, valorInicial - 0.01));

            ofertas.Add(new Oferta(this.Ticker, clear, 'V', 1200, valorInicial + 0.01));
            ofertas.Add(new Oferta(this.Ticker, xp, 'V', 300, valorInicial + 0.01));
            ofertas.Add(new Oferta(this.Ticker, modal, 'V', 100, valorInicial + 0.03));
            ofertas.Add(new Oferta(this.Ticker, nuInvest, 'V', 600, valorInicial + 0.02));
            ofertas.Add(new Oferta(this.Ticker, xp, 'V', 1000, valorInicial + 0.01));

            return ofertas;
        }
    }
}
