using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    
    class Program
    {

        

        static void Main(string[] args)
        {
            String text = "";
            Console.WriteLine("Enter file address:");
            String address = Console.ReadLine();
            try
            {
                text = System.IO.File.ReadAllText(address);
            }
            catch
            {
                Console.Error.WriteLine("File not found.");
            }
            String[] words = text.Split(' ');
            Analyzer analyzer = new Analyzer(words);
            Console.ReadKey();

        }
    }

    class Analyzer
    {

        Dictionary<String, int> results;
        Tuple<String, int> first;
        Tuple<String, int> second;
        Tuple<String, int> third;

        public Analyzer(String[] words)
        {
            results = new Dictionary<String, int>();
            foreach (String word in words) 
            {
                readWord(word);
            }
        }

        private void readWord(String word)
        {
            Console.WriteLine(word);
            if (results.ContainsKey(word))
            {
                /*
                int num;
                results.TryGetValue(word, out num);
                num++;
                results.Add(word, num);
                */
                results[word] += 1;
            }
            else
            {
                results.Add(word, 1);
            }
        }

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

        private void rank(Tuple<String, int> t)
        {
            if(t.Item2 > first.Item2)
            {
                first = t;
            }
            else if (t.Item2 > second.Item2)
            {
                second = t;
            }
            else if (t.Item2 > third.Item2)
            {
                third = t;
            }
        }

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
