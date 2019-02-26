using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class wordInfo
    {
        private string word;
        private string meaning;

        //cons
        public wordInfo(string w, string m) {
            this.word = w;
            this.meaning = m;
        }

        //getters
        public string getWord() {
            return this.word;
        }

        public string getMeaning() {
            return this.meaning;
        }

        //toString
        public string toString() {
            string s = "";
            s += this.word + "\t" + this.meaning;
            return s;
        }
    }
}
