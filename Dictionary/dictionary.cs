using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dictionary
{
    
    class dictionary
    {
        private int currWordNum;
        private int maxWords;
        private wordInfo [] wordList;

        //cons
        public dictionary() {
            currWordNum = 0;
            maxWords = 10000;
            wordList = new wordInfo[maxWords];
        }

        //behavs
        public bool addWord(string w, string m) {
            //if you have max
            if (currWordNum > maxWords) return false;
            
            //if it has a duplicate return false;
            for (int y = 0; y < currWordNum; y++) {
                if (w.CompareTo(wordList[y].getWord()) == 0) return false;
            }

           

            wordInfo temp;
            wordInfo n = new wordInfo(w, m);

            if (getCount() == 0)
            {
                wordList[getCount()] = n;
                currWordNum++;
                return true;
            }
            else {

                int counter = getCount() - 1;

                while (counter >= 0 && n.getWord().CompareTo(wordList[counter].getWord()) < 0)
                {                   
                        wordList[counter + 1] = wordList[counter];
                        counter--;                   
                }
                wordList[counter + 1] = n;
                currWordNum++;
                return true;
            }
        }

        public int getCount() {
            return currWordNum;
        }

        public bool delete(string w) {

            
            int loc;
            loc = binarySearch(w);

            if (loc == -1) {
                return false;
            }
            else {
                wordList[loc] = null;
                int counter = loc + 1;
                while (wordList[counter] != null) {
                    wordList[counter - 1] = wordList[counter];
                    counter++;
                }
                currWordNum--;
                

                return true;
            }

        }
        public string getMeaning(string word) {
            int loc;
            loc = binarySearch(word);
            if (loc == -1)
            {
                return "[ERROR]\nWord is not found!Try again please.";
            }
            else {
                return wordList[loc].getMeaning();
            }
            
        }

        public int binarySearch(string wi)
        {
            int min = 0;
            int max = getCount() - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (wi.CompareTo(wordList[mid].getWord()) == 0) //wi == wordList[mid].getWord()
                {
                    return mid;
                }
                else if (wi.CompareTo(wordList[mid].getWord()) < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


        public string printWordList()
        {
            string s = "===Dictionary===\n";
            s += "\nWords";

            for (int x = 0; x < getCount(); x++)
            {
                s += "\n" + Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(wordList[x].getWord());
            }
            return s;
        }

        public string printDictionary() {
            string s = "===Dictionary===\n";
            s += "\nWord:\t\t\t" + "Meaning:";

            for (int x = 0; x < getCount(); x++) {
                s += "\n" + Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(wordList[x].getWord()) + "\t\t\t" + wordList[x].getMeaning();
            }
            return s;
        }
    }
}

