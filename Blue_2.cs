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
        public Blue_2(string input, string needToDelet) : base(input)
        {
            _output = string.Empty;
            _needToDelet = needToDelet;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_needToDelet) || string.IsNullOrEmpty(Input))
            {
                _output = string.Empty;
                return;
            }
            string[] temporaryWhileLess50 = Input.Split(' ');
            string res = "";
            foreach (string word in temporaryWhileLess50)
            {
                if (!word.Contains(_needToDelet))
                {
                    if (res.Length > 0)
                    {
                        res += " " + word;
                    }
                    else
                    {
                        res += word;
                    }
                }
                else 
                {
                    if (word.Length > 0 && char.IsPunctuation(word[0]))
                    {
                        if (res.Length > 0)
                        {
                            res += " " + word[0];
                        }
                        else
                        {
                            res += word[0];
                        }
                    }
                    if (word.Length > 1 && char.IsPunctuation(word[word.Length - 2]))
                    {
                        res += word[word.Length - 2];
                    }
                    if (word.Length > 0 && char.IsPunctuation(word[word.Length - 1]))
                    {
                        res += word[word.Length - 1];
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
