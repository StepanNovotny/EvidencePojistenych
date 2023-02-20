using Pojisteni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pojisteni
{
	class Akce
	{
		
		private bool PovolenyVstup;
		private string PovoleneZnaky =  "0123456789";
		UpravaTextu upravaTextu = new UpravaTextu();	
		private List<Pojistenec> pojistenci = new List<Pojistenec>();

		public void PridaniPojistence()
		{
			Console.WriteLine("Zadejte jméno pojištěného:"); //Zadání jména
			
			string jmeno;
			do	//Kontrola vztupu
			{
				jmeno = Console.ReadLine().Trim();
				if (!string.IsNullOrEmpty(jmeno))
				{
					PovolenyVstup = true;
				}
				else
				{
					PovolenyVstup = false;
					upravaTextu.NeplatnyVstup("jméno");
					upravaTextu.SmazatLinku();

				}
			} while (!PovolenyVstup);
			

			Console.WriteLine("Zadejte příjmení pojištěnce:"); //Zadání příjmení
			string prijmeni;
			do //Kontrola vztupu
			{
				prijmeni = Console.ReadLine().Trim();
				if (!string.IsNullOrEmpty(prijmeni))
				{
					PovolenyVstup = true;
				}
				else
				{
					PovolenyVstup = false;
					upravaTextu.NeplatnyVstup("příjmení");
					upravaTextu.SmazatLinku();

				}
			} while (!PovolenyVstup);



			Console.WriteLine("Zadejte telefonní číslo:"); //Zadání tefenního čísla			

			string tel;
			do //Kontrola vztupu
			{
				
				tel = Console.ReadLine().Trim();
				if (string.IsNullOrEmpty(tel))
				{
					PovolenyVstup = false;
					upravaTextu.NeplatnyVstup("telefonní číslo");
					upravaTextu.SmazatLinku();
				}
				else
				{
					for (int i = 0; i < tel.Length; i++)
					{
						if (!PovoleneZnaky.Contains(tel[i]))
						{
							PovolenyVstup = false;
							upravaTextu.NeplatnyVstup("telefonní číslo");
							upravaTextu.SmazatLinku();
							break;
						}
						else if ((tel.Length<3)||(tel.Length > 12))
						{
							PovolenyVstup = false;
							Console.WriteLine("Telefonní číslo musí mít 3 až 12 cifer. Pokračujte libovolnou klavesou.");					
							upravaTextu.SmazatLinku();
							break;

						}
						else
						{
							PovolenyVstup = true;
						}

					}
				}
			} while (!PovolenyVstup);

			Console.WriteLine("Zadejte věk:"); //Zadání věku
			int vek;
			while (!int.TryParse(Console.ReadLine().Trim(), out vek) || !(vek > 0))
			{
				upravaTextu.NeplatnyVstup("věk");
				upravaTextu.SmazatLinku();
			}
			var osoba = new Pojistenec(jmeno, prijmeni, tel, vek);

			if (!pojistenci.Contains(osoba))
			{
				pojistenci.Add(new Pojistenec(jmeno, prijmeni, tel, vek));
				Console.WriteLine("Pojištěnec {0} {1} byl zapsán.",jmeno,prijmeni);
				upravaTextu.Pokracovani(); 
				Console.Clear();
			}
			else
			{
				Console.WriteLine("Pojištěnec {0} {1} je již zapsán v databázi.", jmeno, prijmeni);
				upravaTextu.Pokracovani();
			}
			
		}
		public void VypsatPojistene()
		{
			if (pojistenci.Count > 0)
			{
				foreach (Pojistenec pojistenciVypis in pojistenci)
				{
					Console.WriteLine(pojistenciVypis);
				}							
			}
			else
			{
				
				Console.WriteLine("Žádní pojištěnci nejsou zapsáni.");
				
				
			}
			
			upravaTextu.Pokracovani(); 
			Console.Clear();
		}
		public void NajitPojistence()
		{
			if(pojistenci.Count > 0)
			{
				Console.WriteLine("Zadejte jméno pojištěného:"); 
				
				string jmenoNajit;
				do
				{
					jmenoNajit = Console.ReadLine().Trim(); //kontrola vztupu na jméno pojištěnce
					if (!string.IsNullOrEmpty(jmenoNajit))
					{
						PovolenyVstup = true;
					}
					else
					{
						PovolenyVstup = false;
						upravaTextu.NeplatnyVstup("jméno");
						upravaTextu.SmazatLinku();

					}
				} while (!PovolenyVstup);

				Console.WriteLine("Zadejte příjmení:");
				string prijimeniNajit;
				do
				{
					prijimeniNajit = Console.ReadLine().Trim(); //kontrola vztupu na příjmenní pojištěnce
					if (!string.IsNullOrEmpty(prijimeniNajit))
					{
						PovolenyVstup = true;
					}
					else
					{
						PovolenyVstup = false;
						upravaTextu.NeplatnyVstup("příjmení");
						upravaTextu.SmazatLinku();

					}
				} while (!PovolenyVstup);

				bool PojistenecNalezen = false;
				foreach (Pojistenec pojistenec in pojistenci) //Hledání pojištěnce
				{
					if (pojistenec.Jmeno.ToLower()==jmenoNajit.ToLower() && pojistenec.Prijmeni.ToLower()==prijimeniNajit.ToLower()) 
					{
						PojistenecNalezen = true;
						Console.WriteLine(pojistenec);
						
					}
					else
					{
						PojistenecNalezen = false;
						
					}
					
				}
				if (!PojistenecNalezen)
				{
					Console.WriteLine("Pojištěnec nenalezen.");
					upravaTextu.Pokracovani();
				}
				else
				{
					upravaTextu.Pokracovani();
				}
			}
			else
			{
				Console.WriteLine("Žádní pojištěnci nejsou zapsáni.");
				upravaTextu.Pokracovani();
			}
			
			
			Console.Clear();
		}
		public void SmazatPojistence()
		{
			int CisloNaSmazani;
			string Rozhodnuti;
			int PocetNalezenychPojistencu = 0;
			if (pojistenci.Count > 0)
			{
				
				Console.WriteLine("Zadejte jméno pojištěnce, kterého chcete smazat:");

				string jmenoNajit;
				do
				{
					jmenoNajit = Console.ReadLine().Trim(); //kontrola vztupu na jméno pojištěnce na  smazání
					if (!string.IsNullOrEmpty(jmenoNajit))
					{
						PovolenyVstup = true;
					}
					else
					{
						PovolenyVstup = false;
						upravaTextu.NeplatnyVstup("jméno");
						upravaTextu.SmazatLinku();

					}
				} while (!PovolenyVstup);

				Console.WriteLine("Zadejte příjmení pojištěnce, kterého chcete smazat:");
				string prijimeniNajit;
				do
				{
					prijimeniNajit = Console.ReadLine().Trim(); //kontrola vztupu na příjmenní pojištěnce na smazání
					if (!string.IsNullOrEmpty(prijimeniNajit))
					{
						PovolenyVstup = true;
					}
					else
					{
						PovolenyVstup = false;
						upravaTextu.NeplatnyVstup("příjmení");
						upravaTextu.SmazatLinku();

					}
				} while (!PovolenyVstup);

				
				foreach (Pojistenec pojistenec in pojistenci) //Zjištění počtu nalezených pojištěnců
				{
					if (pojistenec.Jmeno.ToLower() == jmenoNajit.ToLower() && pojistenec.Prijmeni.ToLower() == prijimeniNajit.ToLower())
					{
						PocetNalezenychPojistencu++;
						
						
						
					}
					

				}
				if (PocetNalezenychPojistencu > 1)
				{
					foreach (Pojistenec pojistenec in pojistenci) //Vypsání pojištěnců když je nalezen více než jeden
					{
						if (pojistenec.Jmeno.ToLower() == jmenoNajit.ToLower() && pojistenec.Prijmeni.ToLower() == prijimeniNajit.ToLower())
						{
							

							Console.WriteLine(pojistenec);

						}


					}
					Console.WriteLine("Nalezeno více pojištěnců se stejným jménem. Prosím specifikujte, kterého pojištěnce chcete smazat.");
					int pojistenciNaSmazani = 0;
					int vekNajit;
					string telNajit;
					do
					{
						Console.WriteLine("Zadejte věk pojištěnce, kterého chcete smazat:"); //Zadání věku pojištěnce na smazání
					
						while (!int.TryParse(Console.ReadLine().Trim(), out vekNajit) || !(vekNajit > 0))
						{
							upravaTextu.NeplatnyVstup("věk");
							upravaTextu.SmazatLinku();
						}
						Console.WriteLine("Zadejte telefonní číslo pojištěnce, kterého chcete smazat:");
						
						do
						{
							telNajit = Console.ReadLine().Trim(); //kontrola vztupu na tel číslo pojištěnce na smazání
							if (!string.IsNullOrEmpty(telNajit))
							{
								PovolenyVstup = true;
							}
							else
							{
								PovolenyVstup = false;
								upravaTextu.NeplatnyVstup("telefonní číslo");
								upravaTextu.SmazatLinku();

							}
						} while (!PovolenyVstup);

						foreach (Pojistenec pojistenec in pojistenci) //Smazání pojištěnce podle jména a příjmenní
						{
							if ((pojistenec.Jmeno.ToLower() == jmenoNajit.ToLower()) && (pojistenec.Prijmeni.ToLower() == prijimeniNajit.ToLower()) && (pojistenec.Tel.ToLower() == telNajit.ToLower()) && (pojistenec.Vek == vekNajit))
							{
								pojistenciNaSmazani++;
								break;


							}
							
							


						}
						if(pojistenciNaSmazani == 0) //Když je pojištěnec nenalezen pomocí přidaných detailů
						{
							Console.WriteLine("Pojištěnec nenalezen. Zadané telefonní číslo nebo věk se neshoduje. Pokračujte libovolnou klávesou a zadejte znovu."); 

							upravaTextu.SmazatLinky();
							

						}

					} while(pojistenciNaSmazani == 0);
					
					Console.WriteLine("Opravdu chcete pojištěnce jménem {0} {1} smazat? Ano/Ne.",jmenoNajit,prijimeniNajit);
					do
					{
						Rozhodnuti = Console.ReadLine().ToLower();
						if (Rozhodnuti == "ano")
						{
							foreach (Pojistenec pojistenec in pojistenci) //Smazání pojištěnce podle jména a příjmenní
							{
								if ((pojistenec.Jmeno.ToLower() == jmenoNajit.ToLower()) && (pojistenec.Prijmeni.ToLower() == prijimeniNajit.ToLower()) && (pojistenec.Tel.ToLower() == telNajit.ToLower()) && (pojistenec.Vek == vekNajit))
								{
									pojistenci.RemoveAt(pojistenci.IndexOf(pojistenec));
									Console.WriteLine("Pojištěnec {0} {1} byl smazán.", jmenoNajit, prijimeniNajit);
									break;


								}


							}
							break;
						}
						else if (Rozhodnuti == "ne")
						{
							break;
						}
						else
						{
							upravaTextu.NeplatnyVstup("ANO nebo NE");
							upravaTextu.SmazatLinku();
						}
					} while (!(Rozhodnuti == "ano") || !(Rozhodnuti == "ne"));

				}

				else if (PocetNalezenychPojistencu==0)
				{
					Console.WriteLine("Pojistenec nenalezen.");
				}
				else if(PocetNalezenychPojistencu == 1)
				{
					Console.WriteLine("Opravdu chcete pojištěnce jménem {0} {1} smazat? Ano/Ne.",jmenoNajit,prijimeniNajit);
					do
					{
						Rozhodnuti = Console.ReadLine().ToLower();
						if (Rozhodnuti == "ano")
						{
							foreach (Pojistenec pojistenec in pojistenci) //Smazání pojištěnce podle jména a příjmenní
							{
								if ((pojistenec.Jmeno.ToLower() == jmenoNajit.ToLower()) && (pojistenec.Prijmeni.ToLower() == prijimeniNajit.ToLower()))
								{
									pojistenci.RemoveAt(pojistenci.IndexOf(pojistenec));
									Console.WriteLine("Pojištěnec {0} {1} byl smazán.", jmenoNajit, prijimeniNajit);
									break;


								}


							}
							break;
							
						}
						else if (Rozhodnuti == "ne")
						{
							break;
						}
						else
						{
							upravaTextu.NeplatnyVstup("ANO nebo NE");
							upravaTextu.SmazatLinku();
						}
					} while (!(Rozhodnuti == "ano") || !(Rozhodnuti == "ne"));

				}

				
			}
			else
			{

				Console.WriteLine("Žádní pojištěnci nejsou zapsáni.");
				Console.ReadKey();

			}
			upravaTextu.Pokracovani();
			Console.Clear();
		}
	
	}
}
