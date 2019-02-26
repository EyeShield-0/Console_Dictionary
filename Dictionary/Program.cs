using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static dictionary d = new dictionary();//max is defaulted by 10,000
        
        public static void myMenu() {

            Console.Clear();
            Console.WriteLine("===Dictionary===" +
                "\n");
            Console.WriteLine("Please enter the number of your choice below: ");
            Console.WriteLine("\n1. Add New Word ");
            Console.WriteLine("2. Delete Word ");
            Console.WriteLine("3. Get Meaning ");
            Console.WriteLine("4. Dictionary List ");
            Console.WriteLine("5. Print Dictionary ");

            Console.WriteLine("6. Exit ");
        }

        public static int verifierOfInput()
        {
            int input;
            Console.WriteLine(); // for extra space
            while (!int.TryParse(Console.ReadLine(), out input) || input > 6 || input < 0) // cannot enter above 7 and below 0(negative numbers)
            {
                myMenu();
                Console.WriteLine("[Please enter a valid input]");
            }

            return input;
        }

        public static void addWord() {
            string word, meaning;
            bool myBool = true;



            while (myBool) {
                Console.Clear();
                Console.WriteLine("------------Add Word------------");
                Console.Write("\nEnter the word you want to add:");
                word = Console.ReadLine();
                
                Console.Write("\nEnter the meaning:");
                meaning = Console.ReadLine();
                if (word == "" || meaning == "")
                {
                    Console.WriteLine("\nDo not enter null values.");
                    Console.ReadKey();
                    continue;
                }
                
                if (d.addWord(word.ToLower(), meaning.ToLower()))
                {
                    Console.WriteLine("\nYou successfully added the word!");
                    myBool = false;

                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                }
                
                else {
                    string yn;
                    Console.WriteLine("\n[ERROR]00002\nWord must be already existing! Try again? Y/N");
                    yn = Console.ReadLine().ToLower();
                    if (yn.CompareTo("n") == 0)
                    {
                        myBool = false;
                    }
                    else if (yn.CompareTo("y") == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n[ERROR]00001: Enter valid input.");
                        Console.ReadKey();
                    }
                }
            }



        }

        public static void deleteWord() {
            string word;
            bool myBool = true;


            while (myBool)
            {
                Console.Clear();
                Console.WriteLine("------------Delete Word------------");
                Console.Write("\nEnter the word you want to delete:");
                word = Console.ReadLine();



                if (d.delete(word.ToLower()))
                {
                    Console.WriteLine("\nYou successfully deleted the word!");
                    myBool = false;

                    Console.Write("\nPress any key to continue..");
                    Console.ReadKey();
                }
                else
                {
                    string yn;
                    Console.WriteLine("\n[ERROR]\nWord is not found! Try again? Y/N");
                    yn = Console.ReadLine().ToLower();
                    if (yn.CompareTo("n") == 0)
                    {
                        myBool = false;
                    }
                    else if (yn.CompareTo("y") == 0)
                    {
                        continue;
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("\n[ERROR]00001: Enter valid input.");
                        Console.ReadKey();
                    }


                }
            }
        }

        public static void getMeaning() {
            string word;
            Console.Clear();
            Console.WriteLine("------------Get Meaning------------");
            Console.Write("\nEnter the word you want to see meaning:");
            word = Console.ReadLine();
            Console.WriteLine("\n" + d.getMeaning(word.ToLower()));

            Console.Write("\nPress any key to continue..");
            Console.ReadKey();





        }

        public static void dictionaryList() {
            Console.Clear();
            Console.WriteLine(d.printWordList());

            Console.WriteLine("\nFound: " + d.getCount() + " word(s)");

            Console.Write("\nPress any key to continue..");
            Console.ReadKey();

        }

        public static void printDictionary() {
            Console.Clear();
            Console.WriteLine(d.printDictionary());

            Console.WriteLine("\nFound: " + d.getCount() + " word(s)");

            Console.Write("\nPress any key to continue..");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //<pre added words>
            d.addWord("Hello".ToLower(), "Noun. used as a greeting or to begin a telephone conversation.".ToLower());
            d.addWord("Scary".ToLower(), "Adj. frightening; causing fear.".ToLower());
            d.addWord("Run".ToLower(), "Verb. move at a speed faster than a walk, never having both or all the feet on the ground at the same time.".ToLower());
            //</pre added words>
            myMenu();

            int n = verifierOfInput();

            while (n != 6)
            {
                if (n == 1) { addWord(); }
                if (n == 2) { deleteWord(); }
                if (n == 3) { getMeaning(); }
                if (n == 4) { dictionaryList(); }
                if (n == 5) { printDictionary(); }
                myMenu();
                n = verifierOfInput();
            }
            Console.WriteLine("\nThank You For Using Dictionary!");
            Console.ReadKey();            
        }
    }
}
