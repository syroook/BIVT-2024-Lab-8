using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output; 
        public (char, double)[] Output => _output;
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }
        public override string ToString()
        {
            if (_output == null) return null;
            return string.Join(Environment.NewLine, _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            string[] temporaryWhileLess50 = Input.Split(' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/');
            string res = "";
            int cnt = 0;
            if (temporaryWhileLess50.Length == 0) return;
            foreach (string word in temporaryWhileLess50)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    char first = word[0];
                    if (char.IsLetter(first))
                    {
                        res += char.ToLower(first);
                    }
                }
            }
            (char, double)[] letter = new (char, double)[res.Length];
            for (int i = 0; i < letter.Length; i++)
            {
                letter[i] = ('\0', 0);
            }
            foreach (char l in res)
            {
                bool WasFound = false;
                for (int i = 0; i < letter.Count(); i++)
                {
                    if (letter[i].Item1 == l)
                    {
                        letter[i] = (l, letter[i].Item2 + 1);
                        WasFound = true;
                        break;
                    }
                }
                if (!WasFound)
                {
                    for (int j = 0; j < letter.Length; j++)
                    {
                        if (letter[j].Item1 == '\0')
                        {
                            letter[j] = (l, 1);
                            cnt++;
                            break;
                        }
                    }
                }
            }
            var result = new (char, double)[cnt];
            int all = res.Count();
            int ind = 0;
            foreach (var item in letter)
            {
                if (!(item.Item1 == '\0'))
                {
                    double percent = (item.Item2 / all) * 100;
                    result[ind] = (item.Item1, percent);
                    ind++;
                }
            }
            (char, double)[] newResult = result.OrderByDescending(t => t.Item2).ThenBy(t => t.Item1).ToArray();
            _output = newResult;
        }
    }
}
