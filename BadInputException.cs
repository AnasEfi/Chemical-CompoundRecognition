using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ChemicalСompoundRecognition
{
    internal class BadInputException : Exception
    {
        public BadInputException() : base()
        {
            
        }
        public BadInputException(string message): base(message)
        {
        }
    }
}
