using System.Xml.XPath;

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
                bloodType = "A-",
                age = 61,
                Smokes = true,
                AlkoholInLast24H = false
            };
            
            Console.WriteLine("Det har vært en akutt ulykke og Bernt ligger på sykehuset!!!");
            Thread.Sleep(1000);
            Console.WriteLine("Han trenger en ny Nyre!");
            Console.ReadKey();
            Console.Clear();



            Console.WriteLine("Patient name?");
            var pName = Console.ReadLine();

            Console.WriteLine("Patient age?");
            var pAge = Console.ReadLine();
            var pAgeToInt = Convert.ToInt32(pAge);

            Console.WriteLine("Patient bloodtype?");
            var pBloodType = Console.ReadLine();

            Console.WriteLine("Has patient been drinking in the last 24h??");
            Console.WriteLine("1. Yes  2. No");
            bool pDrinking = Console.ReadLine() == "1";

            Console.WriteLine("Does the patient smoke?");
            Console.WriteLine("1. Yes  2. No");
            bool pSmokes = Console.ReadLine() == "1";

            Console.Clear();
            Console.WriteLine("Donors name?");
            var dName = Console.ReadLine();

            Console.WriteLine("Donors age?");
            var dAge = Console.ReadLine();
            var dAgeToInt = Convert.ToInt32(dAge);

            Console.WriteLine("Donors blood type?");
            var dBloodType = Console.ReadLine();

            Console.WriteLine("Has donor been drinking in the last 24h??");
            Console.WriteLine("1. Yes  2. No");
            var dDrinking = Console.ReadLine() == "1";

            Console.WriteLine("Does the donor smoke?");
            Console.WriteLine("1. Yes  2. No");
            var dSmokes = Console.ReadLine() == "1";

            var patient = new Person(pName, pAgeToInt, pBloodType, pSmokes, pDrinking);
            var donor = new Person(dName, dAgeToInt, dBloodType, dSmokes, dDrinking);

            var exit = false;
            var checkAge = false;
            var checkBlood = false;
            Console.Clear();
            while (!exit)
            {
                var Age = checkAge ? patient._age : (int?)null;
                var Age2 = checkAge ? donor._age : (int?)null;
                var pass = checkAge ? checkAges(patient._age) : (string?)null;
                var pass2 = checkAge ? checkAges(donor._age) : (string?)null;

                var Blood = checkBlood ? patient._bloodType : (string?)null;
                var Blood2 = checkBlood ? donor._bloodType : (string?)null;
                var blood = checkBlood ? CheckBlood(patient._bloodType, donor._bloodType) : (string?)null;

                Console.WriteLine($"Patient  - {patient._name}              Donor - {donor._name}");
                Console.WriteLine($"   Age -                {Age} {pass} : {Age2} {pass2}");
                Console.WriteLine($"   BloodType -          {Blood} {blood} : {Blood2} {blood}");
                Console.WriteLine($"   Smokes -            {patient._smokes} : {donor._smokes}");
                Console.WriteLine($"   Alko. in last 24h - {patient._alcoLast24} : {donor._alcoLast24}");
                Console.WriteLine();
                Console.WriteLine("1. Test");
                Console.WriteLine("2. Check success rate");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        checkAge=true;
                        checkBlood = true;
                        break;
                    case "2":
                        CheckSuccessRate(patient,donor);
                        break;
                    case "3":
                        exit = true;
                        break;
                }

                Console.Clear();
            }
        }

        static void CheckSuccessRate(Person patient, Person donor)
        {
            int chance = 0;

            bool blood = patient._bloodType == donor._bloodType;
            bool pAge = patient._age < 60;
            bool dAge = donor._age < 60;

            if (pAge) chance += 20;
            else chance -= 10;
            if (dAge) chance += 20;
            else chance -= 10;

            if (patient._smokes) chance -= 10;
            else chance += 10;
            if (donor._smokes) chance -= 10;
            else chance += 10;

            if (donor._alcoLast24) chance -= 20;
            else chance += 20;

            if (patient._alcoLast24) chance -= 10;
            else chance += 20;

            // Use the result of CheckBlood to influence the chance
            string bloodResult = CheckBlood(patient._bloodType, donor._bloodType);
            if (bloodResult == "\u2717")  // If blood types don't match
            {
                chance = 0;
            }
            else if (bloodResult == "\u2713")  // If blood types match
            {
                chance += 10;  // Adjust the chance accordingly
            }

            chance = Math.Max(0, Math.Min(chance, 100));
            Console.WriteLine($"{chance}% success rate!");
            Console.ReadKey();
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