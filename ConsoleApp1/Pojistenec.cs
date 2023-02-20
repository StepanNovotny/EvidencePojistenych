using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pojisteni
{
	class Pojistenec
	{
		public string Jmeno { get; private set; }
		public string Prijmeni { get; private set; }
		public string Tel { get; private set; }
		public int Vek { get; private set; }

		public Pojistenec(string Jmeno, string Prijmeni, string Tel, int Vek)
		{
			this.Jmeno = Jmeno;
			this.Prijmeni = Prijmeni;
			this.Tel = Tel;
			this.Vek = Vek;
		}

		public override string ToString()
		{
			return Jmeno + "\t" + Prijmeni + "\t" + Vek + "\t" + Tel;
		}

		public override bool Equals(object? obj)
		{
			return obj is Pojistenec pojistenec &&
				   Jmeno.ToLower() == pojistenec.Jmeno.ToLower() &&
				   Prijmeni.ToLower() == pojistenec.Prijmeni.ToLower() &&
				   Tel == pojistenec.Tel &&
				   Vek == pojistenec.Vek;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Jmeno, Prijmeni, Tel, Vek);
		}
	}
}
