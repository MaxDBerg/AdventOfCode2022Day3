using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2022Day3
{
    internal class Program
    {
        public static List<char> chars = new List<char>();

        public static Dictionary<char, int> alphabet = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            int index = 1;
            int points = 0;
            
            for (int i = 0; i < 26; i++)
            {
                alphabet.Add((char)('a' + i), i + 1);
            }

            for (int i = 0; i < 26; i++)
            {
                alphabet.Add((char)('A' + i), i + 27);
            }

            Problem1(points, index);

            Problem2(points, index);
            
        }
        public static void Problem1(int points, int index)
        {
            foreach (string line in File.ReadLines(@"C:\Users\maxda\OneDrive\Skrivbord\AOC2022Day3.txt"))
            {
                List<char> Bag1 = new List<char>();

                List<char> Bag2 = new List<char>();

                Bag1 = line.Substring(0, line.Length / 2).ToList();

                Bag2 = line.Substring(line.Length / 2, line.Length / 2).ToList();

                foreach (char item1 in Bag1)
                {

                    if (Bag2.Contains(item1))
                    {
                        chars.Add(item1);
                    }

                }
                var noCharsDupes = new HashSet<char>(chars);

                foreach (var cha in noCharsDupes)
                {
                    Console.WriteLine("Index: {0} | Char: {1}", index, cha);
                    points += alphabet[cha];
                    Console.WriteLine(points);
                }
                Bag2.Clear();
                Bag1.Clear();
                chars.Clear();
                index++;
            }
        }
        public static void Problem2(int points, int index)
        {
            int bag = 1;

            List<char> Bag1 = new List<char>();
            List<char> Bag2 = new List<char>();
            List<char> Bag3 = new List<char>();

            foreach (string line in File.ReadLines(@"C:\Users\maxda\OneDrive\Skrivbord\AOC2022Day3.txt"))
            {
                if (bag == 1) { Bag1 = line.ToList(); } else if (bag == 2) { Bag2 = line.ToList(); } else if (bag == 3) { Bag3 = line.ToList(); }
                bag++;
                if (bag == 4) 
                {
                    var Bag1NoDupes = new HashSet<char>(Bag1);
                    var Bag2NoDupes = new HashSet<char>(Bag2);
                    var Bag3NoDupes = new HashSet<char>(Bag3);


                    foreach (char item1 in Bag1NoDupes)
                    {

                        if (Bag2NoDupes.Contains(item1))
                        {
                            if (Bag3NoDupes.Contains(item1))
                            {
                                chars.Add(item1);
                            }
                        }

                    }

                    var noCharsDupes = new HashSet<char>(chars);

                    foreach (var cha in noCharsDupes)
                    {
                        Console.WriteLine("Index: {0} | Char: {1}", index, cha);
                        points += alphabet[cha];
                        Console.WriteLine(points);
                    }
                    Bag1NoDupes.Clear();
                    Bag2NoDupes.Clear();
                    Bag3NoDupes.Clear();
                    Bag3.Clear();
                    Bag2.Clear();
                    Bag1.Clear();
                    chars.Clear();
                    index++;
                    bag = 1;
                }
            }
        }
    }
}