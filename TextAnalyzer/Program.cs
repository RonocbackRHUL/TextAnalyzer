using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    /// <summary>
    /// Takes a text file and outputs the three most used words.
    /// </summary>
    class Program
    {

        

        static void Main(string[] args)
        {
            String text = "";
            Console.WriteLine("Enter file address:");
            String address = Console.ReadLine();
            //Attempt to read text file
            try
            {
                text = System.IO.File.ReadAllText(address);
            }
            catch
            {
                Console.Error.WriteLine("File not found.");
            }
            String[] words = text.Split(' ');
            //Analyze most used words
            Analyzer analyzer = new Analyzer(words);
            Console.ReadKey();

        }
    }

    /// <summary>
    /// Analyzes most used words from collection of words.
    /// </summary>
    class Analyzer
    {

        Dictionary<String, int> results;
        Tuple<String, int> first = Tuple.Create<string, int>("foo", 1);
        Tuple<String, int> second = Tuple.Create<string, int>("foo", 1);
        Tuple<String, int> third = Tuple.Create<string, int>("foo", 1);

        public Analyzer(String[] words)
        {
            results = new Dictionary<String, int>();
            foreach (String word in words) 
            {
                //Updates dictionary with word
                readWord(word);
            }
            mostUsed();
        }

        /// <summary>
        /// Update usage dictionary.
        /// </summary>
        /// <param name="word"></param>
        private void readWord(String word)
        {
            Console.WriteLine(word);
            if (results.ContainsKey(word))
            {
                results[word] += 1; //Increments existing entry
            }
            else
            {
                results.Add(word, 1); //Adds new word to dictionary
            }
        }

        /// <summary>
        /// Creates tuple of word and number of uses then uses it to rank words.
        /// </summary>
        private void mostUsed()
        {
            
            foreach(String word in results.Keys)
            {
                int curVal = 0;
                results.TryGetValue(word, out curVal);
                var cur = Tuple.Create(word, curVal);
                rank(cur);
                
            }
            printRanking();

        }

        /// <summary>
        /// Check ranking of word.
        /// </summary>
        /// <param name="t">Tuple of word and its number of uses</param>
        private void rank(Tuple<String, int> t)
        {
            if(t.Item2 > first.Item2)
            {
                first = t; //Update first
            }
            else if (t.Item2 > second.Item2)
            {
                second = t; //Update second
            }
            else if (t.Item2 > third.Item2)
            {
                third = t; //Update third
            }
        }

        /// <summary>
        /// Print top three ranking of all words.
        /// </summary>
        private void printRanking()
        {
            Console.Write("Most used word: ");
            Console.WriteLine(first.Item1);
            Console.Write("Second most used word: ");
            Console.WriteLine(second.Item1);
            Console.Write("Third most used word: ");
            Console.WriteLine(third.Item1);
        }
    }
}
