using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayZan.Framework.Contracts.Pocos
{
  public   class QRCodemessage 
    {
        public string Result { get; private set; }

        public QRCodemessage(string result)
        {
            Result = result;
        }
    }
}
