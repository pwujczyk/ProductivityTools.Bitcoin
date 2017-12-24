using BitcoinSimpleClientObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinSimpleClientPSModule
{
    public abstract class BaseCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "TestNet or Main Bitcoin Network")]
        public Network NetworkType { get; set; }

    }
}
