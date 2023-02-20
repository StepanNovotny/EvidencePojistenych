using Pojisteni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
	class Program
	{
		static void Main(string[] args)
		{

			
			Akce akce = new Akce();
			string volba = "0";
			while (volba != "5")
			{
				Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
				Console.WriteLine("\tEvidence pojištěných");
				Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

				Console.WriteLine("Vyberte si akci:");
				Console.WriteLine("1 - Přidat nového pojištěného");
				Console.WriteLine("2 - Vypsat všechny pojiťěné");
				Console.WriteLine("3 - Vyhledat pojištěného");
				Console.WriteLine("4 - Smazat pojištěného");
				Console.WriteLine("5 - Konec");

				volba = Console.ReadLine();

				string volbaCislo = volba;
				switch (volbaCislo)
				{
					case "1":

						akce.PridaniPojistence();

						break;

					case "2":

						akce.VypsatPojistene();

						break;

					case "3":

						akce.NajitPojistence();

						break;

					case "4":

						akce.SmazatPojistence();

						break;

					case "5":
						Console.WriteLine("Kliknutím na libovolnou klávesu aplikaci ukončíte...");
						Console.ReadKey();
						break;

					default:

						Console.WriteLine("Neplatná volba prosím stiskněte libovolnou klávesu a zadejte znovu.");
						Console.ReadKey();
						Console.Clear();

						break;

				}

			}

		}
	}
}
