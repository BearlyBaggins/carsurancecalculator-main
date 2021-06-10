using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindesheimAD2021AutoVerzekeringsPremie.Implementation
{
    class Vehicle
    {
        public double PowerInKw { get; private set; } // int naar double veranderd. Anders krijg je geen cijfers achter de komma bij het berekenen van premies.
        public int ValueInEuros { get; private set; }
        public int Age { get; private set; }

        internal Vehicle (double PowerInKw, int ValueInEuros, int constructionYear)
        {
            this.PowerInKw = PowerInKw;
            this.ValueInEuros = ValueInEuros;
            Age = constructionYear > DateTime.Now.Year ? 0 : DateTime.Now.Year - constructionYear;            
        }
    }
}
