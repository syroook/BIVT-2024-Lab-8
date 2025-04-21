using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _needToDelet;//последовательность
        public string Output => _output;
        public Blue_2(string input, string del) : base(input)
        {
            _output = string.Empty;
            _needToDelet = del;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_needToDelet) || string.IsNullOrEmpty(Input))
            {
                _output = string.Empty;
                return;
            }
            string[] word = Input.Split(' ');
            string res = "";
            foreach (string w in word)
            {
                if (!w.Contains(_needToDelet))
                {
                    if (res.Length > 0)
                    {
                        res += " " + w;
                    }
                    else
                    {
                        res += w;
                    }
                }
                else 
                {
                    if (w.Length > 0 && char.IsPunctuation(w[0]))
                    {
                        if (res.Length > 0)
                        {
                            res += " " + w[0];
                        }
                        else
                        {
                            res += w[0];
                        }
                    }
                    if (w.Length > 1 && char.IsPunctuation(w[w.Length - 2]))
                    {
                        res += w[w.Length - 2];
                    }
                    if (w.Length > 0 && char.IsPunctuation(w[w.Length - 1]))
                    {
                        res += w[w.Length - 1];
                    }
                }
                _output = res.Trim();
            }
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output)) return string.Empty;
            return _output;
        }
    }
}
