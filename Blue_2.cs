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
        private string _needToDelete;
        public string Output => _output;
        public Blue_2(string input, string needToDelete) : base(input)
        {
            _output = null;
            _needToDelete = needToDelete;
        }
        public override void Review()
        {
            //лишние пробелы
            if (string.IsNullOrEmpty(_needToDelete) || string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }
            string[] SplitEachWhiteSpace = Input.Split(' ');
            string res = "";
            foreach (string word in SplitEachWhiteSpace)
            {
                if (!word.Contains(_needToDelete)) //without
                {
                    if (res.Length > 0) //not empty
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
                    if (word.Length > 0 && char.IsPunctuation(word[0])) // -
                    {
                        if (res.Length > 0) //not empty
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
                        // word,,
                        res += word[word.Length - 2];
                    }
                    if (word.Length > 0 && char.IsPunctuation(word[word.Length - 1]))
                    {
                        res += word[word.Length - 1];
                    }
                }
                _output = res.Trim(); //delete whitespace
            }


        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output)) return null;
            return _output;
        }
    }
}
