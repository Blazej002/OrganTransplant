namespace OrganTransplant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Per1 = new
            {
                name = "Bernt",
                bloodType = "A+",
                age = 26,
                Smokes = false,
                AlkoholInLast24H = false
            };
            var Per2 = new
            {
                name = "Kåre",
                bloodType = "A+",
                age = 55,
                Smokes = true,
                AlkoholInLast24H = false
            };


            Console.WriteLine("Det har vært en akutt ulykke og Bernt ligger på sykehuset!!!");
            Thread.Sleep(1000);
            Console.WriteLine("Han trenger en ny Nyre!");
            Console.ReadKey();
            Console.Clear();
            var exit = false;
            var checkAge = false;
            var checkBlood = false;
            var checkAlko = false;
            while (!exit)
            {
                var Age = checkAge ? Per1.age : (int?)null;
                var Age2 = checkAge ? Per2.age : (int?)null;
                var pass = checkAge ? checkAges(Per1.age): (string?)null;
                var pass2 = checkAge ? checkAges(Per2.age) : (string?)null;

                var Blood = checkBlood ? Per1.bloodType : (string?)null;
                var Blood2 = checkBlood ? Per2.bloodType : (string?)null;
                var blood = checkBlood ? CheckBlood(Per1.bloodType, Per2.bloodType): (string?)null;

                Console.WriteLine($"Patient  - {Per1.name}              Donor - {Per2.name}");
                Console.WriteLine($"   Age -                {Age} {pass} : {Age2} {pass2}");
                Console.WriteLine($"   BloodType -          {Blood} {blood} : {Blood2} {blood}");
                Console.WriteLine($"   Smokes -            {Per1.Smokes} : {Per2.Smokes}");
                Console.WriteLine($"   Alko. in last 24h - {Per1.AlkoholInLast24H} : {Per2.AlkoholInLast24H}");
                Console.WriteLine();
                Console.WriteLine("1. Check age requerments");
                Console.WriteLine("2. Check Blood requerments");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        checkAge=true;
                        break;
                    case "2":
                        checkBlood = true;
                        break;
                    case "3":
                        exit = true;
                        break;
                }

                Console.Clear();
            }
        }

        static string CheckBlood(string BloodType1, string bloodType2)
        {
            if (bloodType2 == BloodType1)
            {
                return "\u2713";
            }

            return "\u2717";
        }
        private static string checkAges(int person)
        {
            string s = "";
            if (person < 60)
            {
                {
                    s = "\u2713";
                    return s;
                }
            }

            s = "\u2717";
            return s;
        }
    }
}