using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeYarışma
{
   public  class WordProvider
    {
        SqlConnection connection;
        private static readonly object _lockSync = new object();
        public WordProvider()
        {
            connection = new SqlConnection(@"server=. ; initial catalog=WordsData; integrated security=true");

        }
        public List<WordData>GetAll()
        {
            List<WordData> wordslist = new List<WordData>();
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Words", connection);
            SqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                WordData word = new WordData();
                word.SozcukId = Convert.ToInt32(dr[0]);
                word.Sözcükler = dr[1].ToString();
                wordslist.Add(word);
            }
            connection.Close();
         return wordslist;
        }
        public List<string> Eslesti_miTest(List<string> myword, int i)
        {
            WordProvider provider = new WordProvider();

           
                List<string> localWord = myword;
                List<string> result = new List<string>();
               
                List<string> words_all = provider.GetAll().Select(x => x.Sözcükler).ToList();

                foreach (var w in localWord.ToList())
                {
                    if (words_all.Contains(w.ToLower()))
                    {
                        result.Add(w);
                    }

                }
                return result;
          
            }

        

    }
}
