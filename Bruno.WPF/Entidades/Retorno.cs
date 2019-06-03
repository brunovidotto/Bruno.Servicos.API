using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruno.WPF.Entidades
{
    public class Retorno
    {
        public string message { get; set; }
        public string exceptionMessage { get; set; }
        public string exceptionType { get; set; }
        public string stackTrace { get; set; }
    }
}
