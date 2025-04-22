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
            _output = new string[0];
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output);
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
                return;
            }
            string[] devide = Input.Split(' '); 
            string[] res = new string[devide.Length]; 
            string temporaryWhileLess50 = "";
            int count = 0;
            for (int i = 0; i < devide.Length; i++)
            {
                string w = devide[i];
                if (temporaryWhileLess50.Length + w.Length + 1 <= 50)
                {
                    if (temporaryWhileLess50.Length > 0)
                    {
                        temporaryWhileLess50 += " " + w;
                    }
                    else
                    {
                        temporaryWhileLess50 += w;
                    }
                }
                else 
                {
                    res[count] = temporaryWhileLess50;
                    count++;
                    temporaryWhileLess50 = w;
                }
            }
            if (!string.IsNullOrEmpty(temporaryWhileLess50))
            {
                res[count++] = temporaryWhileLess50; 
            }
            _output = res;
        }
        
    }
}
