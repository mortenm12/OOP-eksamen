using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Exeptions
{
    class NotValidTextExeption : Exception
    {
        public string Text { get; set; }

        public NotValidTextExeption()
        {

        }

        public NotValidTextExeption(string text)
        {
            Text = text;
        }
    }
}
