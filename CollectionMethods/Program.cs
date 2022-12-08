namespace CollectionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sehirler = new List<Sehir>()
            {
                new Sehir()
                {
                    PlakaNo = 6,
                    Adi="Ankara"
                }
            };
            Sehir[] yeniSehirler = new Sehir[2]
            {
                new Sehir()
                {
                    Adi = "New York"

                },
                new Sehir()
                {
                    Adi = "Chicago"

                }
            };
            // 1.yöntem:
            //foreach (var yeniSehir in yeniSehirler)
            //{
            //    sehirler.Add(yeniSehir);
            //}
            //foreach (var sehir in sehirler)
            //{
            //    Console.WriteLine(sehir.Adi);
            //}

            // 2. yöntem:
            sehirler.AddRange(yeniSehirler);

            foreach (var sehir in sehirler)
            {
                Console.WriteLine(sehir.Adi);
            }

            List<int> sayilar = new List<int>()
            {
                9, 5, 8, 1, 2
            };
            sayilar.Sort();
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }
            sayilar.Reverse();
            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }

            if (sayilar.Contains(1))
                Console.WriteLine("1 Listede Var");
            else
                Console.WriteLine("1 Listede Yok");

            int indexOf9 = sayilar.IndexOf(9); // 0
            Console.WriteLine("9 un İndexi: " + indexOf9);

            sayilar.Insert(0, -1);
            sayilar.RemoveAt(0);



        }
    }
    class Sehir // model
    {
        public byte PlakaNo { get; set; }
        public string Adi { get; set; }
    }
}