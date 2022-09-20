using System;
using System.IO;
using System.Linq;

namespace TextTopWord
{
    class Program
    {
        static void Main(string[]args)
        {
            string path = @"C:\Users\SMN\Desktop\Text1.txt";
            var txt = File.ReadAllText(path);

            var noPuctuationText = new string(txt.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = noPuctuationText.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var dict = new Dictionary<string, int>();

            foreach(string word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict[word] = 1;
            }

            var topWord = dict.OrderByDescending(x => x.Value).Where(n => n.Key.Length > 3).Take(10);

            foreach(KeyValuePair<string,int> top in topWord)
            {
                Console.WriteLine($"Слово '{top.Key}' встречается {top.Value} раз ");
            }
            Console.ReadKey();       
        }
    }
}