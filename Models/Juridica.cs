using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet2.Models
{
    public class Juridica: Pessoa
    {
        public string Cnpj{get;set;}
        public string InscricaoEstadual{get;set;}
        public DateTime Fundacao{get;set;}
        public virtual ICollection<Parceiro> Parceiros{get;set;}
    }
}