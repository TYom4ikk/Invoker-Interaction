using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvokerInteraction
{
    internal class Program
    {
        static Dictionary<string, char[]>Spell = new Dictionary<string, char[]>();
        static public List<char> user_char_arr = new List<char>();
        static string what_skill = string.Empty;
        static string needed_skill = string.Empty;
        static int counter_of_answers = 0;
        static void Main(string[] args)
        {
            Spell.Add("Cold Snap", new char[] { 'Q', 'Q', 'Q' });
            Spell.Add("Ghost Walk", new char[] { 'Q', 'Q', 'W' });
            Spell.Add("Ice Wall", new char[] { 'Q', 'Q', 'E' });
            Spell.Add("EMP", new char[] { 'W', 'W', 'W' });
            Spell.Add("Tornado", new char[] { 'W', 'W', 'Q' });
            Spell.Add("Alacrity", new char[] { 'W', 'W', 'E' });
            Spell.Add("Sun Strike", new char[] { 'E', 'E', 'E' });
            Spell.Add("Forge Spirit", new char[] { 'E', 'E', 'Q' });
            Spell.Add("Meteor", new char[] { 'E', 'E', 'W' });
            Spell.Add("Deaf. Blast", new char[] { 'Q', 'W', 'E' });

            /*            Thread gamethread = new Thread(()=>
                        {

                        });

                        Thread thread = new Thread(() =>
                        {

                        });
                        gamethread.Start();
                        thread.Start();*/
            for(int i = 0;i<10;i++)
            {
                Playgame();
                for (int j = 0; j < 3; j++)
                {
                    UserInput();
                }
                Check();
            }
            Console.WriteLine($"Кол-во ответов: {counter_of_answers}/10");

            Console.ReadKey();
        }

        private static void Playgame()
        {

            Random random = new Random();
            int random_index = random.Next(0, Spell.Count);
            var keys = Spell.Keys;
            needed_skill = keys.ElementAt(random_index);
            Console.WriteLine($"Какая комбинация соответствует способности: {needed_skill} ?");
        }
        private static void Check()
        {
            if (what_skill != string.Empty)
            {
                if (what_skill == needed_skill)
                {
                    Console.WriteLine("\nВерно!");
                    what_skill = string.Empty;
                    counter_of_answers++;
                }
                else
                {
                    Console.WriteLine("\nОшибка!");
                    what_skill = string.Empty;
                }
            }
        }

        private static void UserInput()
        {
                if (user_char_arr.Count == 3)
                {
                    user_char_arr.Clear();
                }

                char user_symbol = Convert.ToChar(Console.ReadKey().KeyChar);
                //Console.WriteLine($"Нажатие клавиши {user_symbol}");
                user_char_arr.Add(user_symbol);

                /*foreach(var item in user_char_arr)
                {
                    Console.Write(item);
                }*/
                foreach (var item in Spell)
                {
                    bool isCorrect = false;
                    for (int i = 0; i < 3; i++)
                    {
                        //Console.WriteLine($"item.Value = {item.Value[i]}, user_char_arr = {user_char_arr[i]}");
                        if (user_char_arr.Count == 3)
                        {
                            if (item.Value[0] == user_char_arr[0] && item.Value[1] == user_char_arr[1] &&
                                item.Value[2] == user_char_arr[2])
                            {
                                isCorrect = true;
                            }
                        }

                    }
                   /* Console.Write("|");
                    foreach (var asd in user_char_arr)
                    {

                        Console.Write(asd + " ");
                    }*/
                    //Console.Write("|");
                    if (isCorrect)
                    {
                        //Console.WriteLine(item.Key);
                        what_skill = item.Key;
                        break;
                    }
                    //Quser_char_arr = new char[] { '0', '0', '0' };
                }
        }
    }
}
