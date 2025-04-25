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
        public override string ToString()
        {
            return $"{_output}";
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            int current = 0;
            bool IsItDigit = false; 
            foreach (char d in Input)
            {
                if (Char.IsDigit(d))
                {
                    if (!IsItDigit) //new number
                    {
                        current = (int)d - '0';
                        IsItDigit = true;
                    }
                    else
                    {
                        current = current * 10 + (int)d - '0';
                    }
                }
                else if (!Char.IsDigit(d) && IsItDigit)
                {
                    IsItDigit = false;
                    _output += current;
                    current = 0;
                }
            }
            if (IsItDigit) //if last is number
            {
                _output += current;
            }
        }
    }
}
