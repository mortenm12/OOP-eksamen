using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Exeptions
{
    /// <summary>
    /// An Exeption there is throw when the text isn't valid.
    /// </summary>
    public class NotValidTextExeption : Exception
    {
        /// <summary>
        /// The text that was't valid.
        /// </summary>
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
