using System;
using System.Linq;

namespace Jacek_Matulewski_C1_Wprowadzenie
{
    class RównanieKwadratowe
    {
        private double a, b, c;
        private double? x1, x2;
        private bool KonieczneObliczenieRozwiązań = true;
        public double? X1
        {
            get
            {
                rozwiąż();
                return x1;
            }
        }
        public double? X2
        {
            get
            {
                rozwiąż();
                return x2;
            }
        }
        public bool MaRozwiązania
        {
            get => X1.HasValue && X2.HasValue;
        }
        private void rozwiąż()
        {
            if (!KonieczneObliczenieRozwiązań) return;
            else{
                double delta = b * b - 4 * a * c;
                if (delta >= 0)
                {
                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                }
                else
                {
                    x1 = null;
                    x2 = null;
                }
            }
        }
        public RównanieKwadratowe(double A, double B, double C)
        {
            UstawWspółczynniki(A, B, C);
        }
        public double A
        {
            get => a;
            set
            {
                if (value != a)
                {
                    a = value;
                    KonieczneObliczenieRozwiązań = true;
                }
            }
        }


        public double B
        {
            get => b;
            set
            {

                if (value != b)
                {
                    b = value;
                    KonieczneObliczenieRozwiązań = true;
                }

            }
        }
        public double C
        {
            get => c;
            set
            {
                if (value != c)
                {
                    c = value;
                    KonieczneObliczenieRozwiązań = true;
                }
            }
        }

        public void UstawWspółczynniki(double A, double B, double C)
        {
            this.a = A;
            this.b = B;
            this.c = C;
            rozwiąż();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            double a = WczytajLiczbę("a= ");
            double b = WczytajLiczbę("b= ");
            double c = WczytajLiczbę("c= ");

            Console.WriteLine("Równanie: " + a + "*x1^2 + " + b + "*x2 + " + c);
            RównanieKwadratowe równanie = new RównanieKwadratowe(a, b, c);

            if (równanie.MaRozwiązania) Console.WriteLine("ma rozwiązania: x1:" + równanie.X1 + ", x2:" + równanie.X2);
            else Console.WriteLine("Brak rozwiązań");

        }
        static void StaryMain()
        {
            int[] wartości = generujTablicęRzutówKostką(30);
            //for(int i=0; i<wyniki.Length; i++) Console.Write(wyniki[i] + " ");

            foreach (double wartość in wartości) Console.Write(wartość + " ");
            //double[] tablica = Array.ConvertAll<int, double>(wartości, i => (double)i);
            //Console.WriteLine("liczzba elementów: " + tablica.Length);
            //Console.WriteLine("suma: " + sumuj(tablica));
            //Console.WriteLine("średnia: " + Program.średnia(tablica));
            //Console.WriteLine("wariancja: " + Program.wariancja(tablica));
            //Console.WriteLine("odchylenie standardowe: " + odchylenieStandardowe(tablica));
            //Console.WriteLine("zakres: " + zakres(tablica));

            //Console.WriteLine("suma: " + tablica.Sum());
            //double średnia = tablica.Average();
            //Console.WriteLine("średnia: " + średnia);
            //double wariancja = tablica.Sum(element => (element - średnia) * (element - średnia)) / tablica.Length;
            //Console.WriteLine("wariancja: " + wariancja);
            //Console.WriteLine("odchylenie standardowe: " + Math.Sqrt(wariancja));
            //Console.WriteLine("zakres: " + tablica);
        }
        static void Równanie()
        {
            double x1, x2;
            double a = WczytajLiczbę("a= ");
            double b = WczytajLiczbę("b= ");
            double c = WczytajLiczbę("c= ");

            Console.WriteLine("Równanie: " + a + "*x1^2 + " + b + "*x2 + " + c);
            (double x1, double x2)? rozwiązania = RównanieKwadratowe(a, b, c);
            if (rozwiązania.HasValue) Console.WriteLine("ma rozwiązania: x1:" + rozwiązania.Value.x1 + ", x2:" + rozwiązania.Value.x2);
            else Console.WriteLine("Brak rozwiązań");
        }
        static double WczytajLiczbę(string tekst)
        {
            Console.Write(tekst);
            return (double.Parse(Console.ReadLine()));
        }
        static (double x1, double x2)? RównanieKwadratowe(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta >= 0)
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                return (x1, x2);
            }
            else return null;
        }
        static void ekstrema(double[] tab, out int indeksMin, out int indeksMax)
        {
            indeksMin = 0;
            indeksMax = 0;
            double mini = 12, maks = 0;
            if (tab == null) throw new ArgumentNullException("przekazano pusty obiekt");
            if (tab.Length == 0) throw new Exception("w tablicy nie ma elementów");

            for (int i = 0; i < tab.Length; i++)
            {
                if (mini > tab[i])
                {
                    mini = tab[i];
                    indeksMin = i;
                }
                if (maks < tab[i])
                {
                    maks = tab[i];
                    indeksMax = i;
                }
            }
        }
        static double zakres(double[] tab)
        {
            int indexMin = 0, indexMax = 0;
            ekstrema(tab, out indexMin, out indexMax);
            //Console.WriteLine($"Wartość[{indexMin}]={tab[indexMin]}, wartość [{indexMax}]={ tab[indexMax]}" );
            return tab[indexMax] - tab[indexMin];
        }
        static double wariancja(double[] tab3)
        {
            if (tab3 == null) throw new ArgumentNullException("przekazano pusty obiekt");
            if (tab3.Length == 0) throw new Exception("w tablicy nie ma elementów");
            double średnia = Program.średnia(tab3);
            double wariancja = 0;
            foreach (double wartość in tab3)
            {
                wariancja += (średnia - wartość) * (średnia - wartość);
            }


            return wariancja / tab3.Length;
        }
        static double odchylenieStandardowe(double[] tab4)
        {
            return Math.Sqrt(wariancja(tab4));
        }
        static double średnia(double[] tab2)
        {
            if (tab2 == null) throw new ArgumentNullException("przekazano pusty obiekt");
            if (tab2.Length == 0) throw new Exception("w tablicy nie ma elementów");
            return sumuj(tab2) / tab2.Length;

        }
        static int[] generujTablicęRzutówKostką(int n = 100)
        {
            int[] tab = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++) tab[i] = r.Next(2, 13);
            return tab;
        }


        static double sumuj(double[] tab)
        {
            double suma = 0;
            foreach (int wartość in tab) suma += wartość;
            return suma;
        }


    }
}
