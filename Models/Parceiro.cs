using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet2.Models
{
    public class Parceiro
    {
        public int Id{get;set;}
        public string TipoPessoa{get;set;}
        public string Atividade{get;set;}
        public virtual ICollection<Juridica> Juridicas {get;set;}
        public int FisicaId {get;set;}
        public virtual Fisica Fisica{get;set;}

    }
}