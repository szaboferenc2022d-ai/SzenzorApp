using System;
using System.Collections.Generic;
using System.Text;

namespace SzenzorApp
{
    internal class KameraSzenzor : Szenzor
    {
        int FelbontasMP { get; set; }

    public KameraSzenzor(string azonosito, int fogyasztomW, int osszesSzenzorSzama, int felbontasMP) : base(azonosito, fogyasztomW, osszesSzenzorSzama)
        {
            FelbontasMP = felbontasMP;
        }

        public override int NapiEnergiaIgeny(int orakSzama)
        {
            return (base.NapiEnergiaIgeny(orakSzama)) + FelbontasMP * 10 * orakSzama;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Felbontás: {FelbontasMP} MP";
        }
    }
}
