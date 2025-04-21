using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;
        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            int current = 0;
            bool digit = false; 
            foreach (char d in Input)
            {
                if (Char.IsDigit(d))
                {
                    if (!digit)
                    {
                        current = (int)d - '0';
                        digit = true;
                    }
                    else
                    {
                        current = current * 10 + (int)d - '0';
                    }
                }
                else if (!Char.IsDigit(d) && digit)
                {
                    digit = false;
                    _output += current;
                    current = 0;
                }
            }
            if (digit)
            {
                _output += current;
            }
        }
        public override string ToString()
        {
            return $"{_output}";
        }
    }
}
