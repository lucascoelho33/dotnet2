using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet2.Models
{
    public class Fisica: Pessoa
    {
        public string Cpf{get;set;}
        public string Rg{get;set;}
        public string Genero{get;set;}
        public DateTime Nascimento{get;set;}
        public virtual ICollection<ReservaHotel> ReservaHotels {get;set;}
        public virtual ICollection<Parceiro> Parceiros {get;set;}

        
    }
}