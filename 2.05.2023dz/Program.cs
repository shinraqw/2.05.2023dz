namespace _2._05._2023dz
{

    public class Program
    {
        static void Main()
        {
            // 1
            Func<string, int[]> GetRainbowColor = delegate (string colorName)
            {
                switch (colorName.ToLower())
                {
                    case "red":
                        return new int[] { 255, 0, 0 };
                    case "orange":
                        return new int[] { 255, 165, 0 };
                    case "yellow":
                        return new int[] { 255, 255, 0 };
                    case "green":
                        return new int[] { 0, 128, 0 };
                    case "blue":
                        return new int[] { 0, 0, 255 };
                    case "indigo":
                        return new int[] { 75, 0, 130 };
                    case "violet":
                        return new int[] { 238, 130, 238 };
                    default:
                        throw new ArgumentException("Invalid rainbow color name.");
                }


                // Тестування анонімного методу
                Console.WriteLine("Rainbow colors:");
                Console.WriteLine($"Red:     {string.Join(",", GetRainbowColor("red"))}");
                Console.WriteLine($"Orange:  {string.Join(",", GetRainbowColor("orange"))}");
                Console.WriteLine($"Yellow:  {string.Join(",", GetRainbowColor("yellow"))}");
                Console.WriteLine($"Green:   {string.Join(",", GetRainbowColor("green"))}");
                Console.WriteLine($"Blue:    {string.Join(",", GetRainbowColor("blue"))}");
                Console.WriteLine($"Indigo:  {string.Join(",", GetRainbowColor("indigo"))}");
                Console.WriteLine($"Violet:  {string.Join(",", GetRainbowColor("violet"))}");




                //2
                Backpack backpack = new Backpack();
                backpack.FillBackpack("blue", "Jansport", "Jansport Inc.", "nylon", 1.5, 50);

                backpack.ItemAdded += delegate (object sender, ItemEventArgs e)
                {
                    Console.WriteLine($"Added item: {e.Item.Name}");
                };

                try
                {
                    Item book = new Item("Book", 10);
                    backpack.AddItem(book);

                    Item waterBottle = new Item("Water bottle", 2);
                    backpack.AddItem(waterBottle);

                    Item laptop = new Item("Laptop", 30);
                    backpack.AddItem(laptop);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(backpack.ToString());



                //3
                int[] numbers = { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };

                int count = numbers.Count(x => x % 7 == 0);

                Console.WriteLine($"The number of elements in the array that are multiples of 7 is: {count}");
                //4
                int[] numbers2 = { -5, 10, -15, 20, -25, 30, -35, 40, -45, 50 };

                int count2 = numbers2.Count(x => x > 0);

                Console.WriteLine($"The number of positive elements in the array is: {count2}");
                //5
                int[] numbers3 = { -5, 10, -15, 20, -5, 30, -35, 40, -45, 50 };

                var negativeUniqueNumbers = numbers3.Where(x => x < 0).Distinct();

                Console.WriteLine("Unique negative numbers in the array:");
                foreach (var number in negativeUniqueNumbers)
                {
                    Console.WriteLine(number);

                }
                //6
                string text = "The quick brown fox jumps over the lazy dog";

                string wordToFind = "fox";

                bool containsWord = text.Split(' ').Any(x => x.Equals(wordToFind));

                Console.WriteLine($"Does the text contain the word '{wordToFind}'? {containsWord}");


            };
        }
    }
}