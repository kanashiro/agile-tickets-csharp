using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTickets.Web.Models
{
    public class Espetaculo
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual IList<Sessao> Sessoes { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        public Espetaculo()
        {
            this.Sessoes = new List<Sessao>();
        }
       
        public virtual IList<Sessao> CriaSessoes(DateTime inicio, DateTime fim, Periodicidade periodicidade)
        {
            IList<Sessao> sessoes = new List<Sessao>();
            int dias = (fim.Date - inicio.Date).Days;
            for (int i = 0; i <= dias; i++)
            {
                Sessao sessao = new Sessao();
                sessao.Espetaculo = this;
                sessao.Inicio = inicio.AddDays(i);

                sessoes.Add(sessao);
            }

            return sessoes;
        }

        public virtual bool Vagas(int qtd, int min)
        {
            int totDisp = IngressosDisponiveisNasSessoes(min);

            if (totDisp >= qtd && qtd >= 0) 
                return true;
            
            return false;
        }

        public virtual bool Vagas(int qtd)
        {
            int totDisp = IngressosDisponiveisNasSessoes(0);

            if (totDisp >= qtd && qtd >= 0) 
                return true;
            
            return false;
        }

        private int IngressosDisponiveisNasSessoes(int minimo)
        {
            int totDisp = 0;

            foreach (Sessao s in Sessoes)
            {
                if (s.IngressosDisponiveis < minimo)
                {
                    return -1;
                }
                totDisp += s.IngressosDisponiveis;
            }
            return totDisp;
        }
    }
}