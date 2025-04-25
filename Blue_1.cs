using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }
        //без символа переноса на конце последней строки.
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output);
            //Environment.NewLine "\r\n  windows"
            // \r курсор в начало строки
            // \n курсор на одну строку вниз
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }
            string[] devide = Input.Split(' '); 
            string[] res = new string[devide.Length]; //count words
            string temporaryWhileLess50 = "";
            int count = 0;
            for (int i = 0; i < devide.Length; i++) //go through words
            {
                string w = devide[i]; //remember the word
                if (temporaryWhileLess50.Length + w.Length + 1 <= 50)
                {
                    if (temporaryWhileLess50.Length > 0) //not empty
                    {
                        temporaryWhileLess50 += " " + w;
                    }
                    else //without space 
                    {
                        temporaryWhileLess50 += w;
                    }
                }
                else //more than 50
                {
                    res[count++] = temporaryWhileLess50;
                    temporaryWhileLess50 = w; //which didn't fit
                }
            }
            if (temporaryWhileLess50.Length > 0) //add last one
            {
                res[count++] = temporaryWhileLess50; 
            }
            _output = new string[count];
            Array.Copy(res, _output, count);
        }
        
    }
}
