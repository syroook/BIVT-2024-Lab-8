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
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
                return;
            }
            string[] word = Input.Split(' '); 
            string[] result = new string[word.Length]; 
            string time = "";
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                string w = word[i];
                if (time.Length + w.Length + 1 <= 50)
                {
                    if (time.Length > 0)
                    {
                        time += " " + w;
                    }
                    else
                    {
                        time += w;
                    }
                }
                else 
                {
                    result[count] = time;
                    count++;
                    time = w;
                }
            }
            if (!string.IsNullOrEmpty(time))
            {
                result[count++] = time; 
            }
            _output = result;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output); 
        }
    }
}
