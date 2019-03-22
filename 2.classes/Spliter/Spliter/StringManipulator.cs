using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spliter
{
    class StringManipulator
    {
        public string Text { get; private set; }

        public StringManipulator(string text)
        {
            Text = text;
        }

        string[]  GetWords()
        {
            char[] seps = { ' ', ';', '.', ',', ':' };
            string[] words = Text.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        string[] GetWordsInLowercase()
        {
            string[] words = GetWords();
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }
            return words;
        }

        Dictionary<string, int> CountWords()
        {
            string[] words = GetWordsInLowercase();
            
            Dictionary<string, int> countedWords = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (countedWords.ContainsKey(word))
                {
                    countedWords[word]++;
                }
                else
                {
                    countedWords[word] = 1;
                }
            }
            return countedWords;
        }

        public void ShowFullInfo()
        {
            Dictionary<string, int> countedWords = CountWords();
            int count = countedWords.Count;
            foreach (var countedWord in countedWords)
            {
                Console.WriteLine($"Word >>> {countedWord.Key} <<< was found >>> {countedWord.Value} <<< time/times. Frequency is equal >>> {(double)countedWord.Value / (double)count} <<<");
            }
        }

        public void ShowReducedInfo()
        {
            Dictionary<string, int> countedWords = CountWords();
            foreach (var countedWord in countedWords)
            {
                Console.WriteLine($">{countedWord.Key} :::: {countedWord.Value}<");
            }
        }
    }
}
