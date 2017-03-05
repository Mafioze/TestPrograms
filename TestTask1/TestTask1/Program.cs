using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestTask1
{
    class Program
    {
        public struct Couple
        {
            public Couple(string strpar, uint intpar)
            {
                value = strpar;
                count = intpar;
            }

            public static Couple operator ++(Couple c)
            {
                c.count++;
                return c;
            }

            public string value;
            public uint count;
        }

        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Введите путь к файлу");
            path = Console.ReadLine();
            Console.WriteLine();

            try
            {
                StreamReader con = new StreamReader(path, System.Text.Encoding.Default);

                List<Couple> dictionary = new List<Couple>(); 

                StringBuilder word = new StringBuilder();
                char symbol;

                List<char> punctuation = new List<char> {',', ' ', '"', '\'', '\t', '-',
                    ':', '(', ')', '.', ';' };
                

                while(!con.EndOfStream)
                {
                    symbol = char.ToLowerInvariant((char)con.Read());

                    if (symbol == -1 || punctuation.Contains(symbol))
                    {
                        if (word.Length > 1)
                        {
                            bool contains = false;
                            for (int i = 0; i < dictionary.Count; i++)
                                if (dictionary[i].value == word.ToString())
                                {
                                    dictionary[i]++;
                                    contains = true;
                                    break;
                                }
                            if(!contains)
                            {
                                dictionary.Add(new Couple(word.ToString(), 1));
                            }
                        }
                        word.Clear();
                    }
                    else
                        word.Append((char)symbol); 
                }

                con.Close();

                dictionary.Sort(delegate (Couple item1, Couple item2)
                { return item2.count.CompareTo(item1.count); });

                for (int i = 0; i < 3; i++)
                    Console.WriteLine(dictionary[i].value + ": " + dictionary[i].count);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
