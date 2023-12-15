namespace М5_exam2
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            (string name, string lastname, int age, bool HasPet,
            string[] PetName, int CountPet, int CountColor, string[] Colors) anketa;

            anketa.age = 0;
            anketa.HasPet = false;
            anketa.PetName = Array.Empty<string>();
            anketa.CountPet = 0;

            Console.Write("Как там тебя?\n  ");
            anketa.name = Console.ReadLine();
            Console.Write("А фамилия?\n  ");
            anketa.lastname = Console.ReadLine();


            while (anketa.age == 0)
            {
                Console.Write("Сколько стукнуло?\n  ");
                int.TryParse(Console.ReadLine(), out anketa.age);
            }


            Console.WriteLine("Ну что, {0}-летний {1} {2}...",
                anketa.age, anketa.name, anketa.lastname);

            Console.Write("Животинка акромя тараканов дома имеется?\nда или нет?\n  ");

            var result = Console.ReadLine();

            if (result == "да")
            {
                anketa.HasPet = true;
                GetPets(out anketa.CountPet, out anketa.PetName);
            }

            anketa.HasPet = result == "да";



            Console.WriteLine("Есть цвета, от которых прёшься?");
            GetColors(out anketa.CountColor, out anketa.Colors);


            ShowResult(anketa);

            Console.ReadKey();

        }

        private static void ShowResult((string name, string lastname, int age,
            bool HasPet, string[] PetName, int CountPet, int CountColor,
            string[] Colors) anketa)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Итак, тебя зовут {0} {1}", anketa.name, anketa.lastname);
            Console.WriteLine("Годков тебе {0}", anketa.age);
            if (anketa.HasPet)
            {
                Console.WriteLine("Имеются животные: ");
                for (int i = 0; i < anketa.PetName.Length; i++)
                {
                    string? pet = anketa.PetName[i];

                    Console.WriteLine("{0}-го зовут {1}", i + 1, pet);
                }
            }
            Console.WriteLine("Твои любимые цвета:");
            foreach (var col in anketa.Colors)
            {
                Console.WriteLine(col);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }


        private static void GetColors(out int countColor, out string[] colors)
        {
            countColor = 0;
            while (countColor == 0)
            {
                Console.WriteLine("Сколько их?");
                int.TryParse(Console.ReadLine(), out countColor);
            }
            colors = new string[countColor];
            for (int i = 0; i < countColor; i++)
            {
                Console.WriteLine("Какой {0}-й?", i + 1);
                colors[i] = Console.ReadLine();
            }
        }

        private static void GetPets(out int countPet, out string[] petName)
        {
            countPet = 0;
            while (countPet == 0)
            {
                Console.WriteLine("Сколько штук цифрой?");
                int.TryParse(Console.ReadLine(), out countPet);
            }
            petName = new string[countPet];
            for (int i = 0; i < countPet; i++)
            {
                Console.WriteLine("Как зовут {0}-го?", i + 1);
                petName[i] = Console.ReadLine();
            }

        }
    }
}