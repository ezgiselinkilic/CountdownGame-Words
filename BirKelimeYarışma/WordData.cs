using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeYarışma
{
   public  class WordData
    {
        int _id;
        string _Sözcükler;
        public int SozcukId 
        {
           get { return _id; }
            set { _id = value; }
        }
        public string Sözcükler
        {
            get { return _Sözcükler; }
            set { _Sözcükler = value; }
        }
    }
}
