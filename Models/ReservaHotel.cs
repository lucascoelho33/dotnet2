using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet2.Models
{
    public class ReservaHotel
    {
        public int Id{get;set;}
        public string NumeroReserva{get;set;}
        public double Valor{get;set;}
        public DateTime DataReserva{get;set;}
        public virtual ICollection<Fisica> Fisicas {get;set;}


    }
}