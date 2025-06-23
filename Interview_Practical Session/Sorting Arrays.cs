using NCalc;

namespace Interview_Practical_Session
{
    public class Sorting_Arrays
    {
        // question 2
        private int[] numbers = { 3, 67, 2, 9, 4, 7, 26, 17, 1 };

        public void SortNumbers()
        {
            Array.Sort(numbers);
        }

        public void PrintNumbers()
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        // question 3
        private string original = "AWUZABOUGI";


        public Sorting_Arrays()
        {
            original = new string(original.Reverse().ToArray());
        }

        // Question 4  
        public string words = "The quick brown fox jumps over the lazy dog";

        public void ReverseWords()
        {
            string[] wordsArray = words.Split(' ');
            Array.Reverse(wordsArray);
            //string reversedWords = string.Join(" ", wordsArray);
            Console.WriteLine(wordsArray);
        }

    }


}
