using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeYarışma
{
    public class wordss
    {
        public int hane { get; set; }
        public List<string> word { get; set; }

        public wordss()
        {
            this.word = new List<string>();
        }
        public wordss(int hane,List<string> word)
        {
            this.hane = hane;
            this.word = word;
        }
    }
}
