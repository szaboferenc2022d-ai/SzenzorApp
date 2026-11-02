using System;
using System.Collections.Generic;
using System.Text;

namespace SzenzorApp
{
    public class Szenzor
    {
        string Azonosito { get; set; }
        protected int fogyasztasmW;
        public int FogyastasmW {
            get { return fogyasztasmW; }
            set {
                if (value < 0)
                {
                    fogyasztasmW = 50;
                }
                else
                {
                    fogyasztasmW = value;
                }
            }
        }
        private static int osszesSzenzorSzama;
        public static int OsszesSzenzorSzama { get; }

        public Szenzor(string azonosito, int fogyasztomW, int osszesSzenzorSzama)
        {
            Azonosito = azonosito;
            FogyastasmW = fogyasztomW;
        }

        public virtual int NapiEnergiaIgeny(int orakSzama)
        {
            return fogyasztasmW * orakSzama;
        }

        public override string ToString()
        {
            return $"Szenzor [Azonosito] | Fogyasztás: [FogyasztasmW] mW";
        }

    }
}
