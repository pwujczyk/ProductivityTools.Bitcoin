using BitcoinSimpleClientObjects;
using PSBitcoinClientCore;
using PSBitcoinCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinSimpleClientPSModule
{
    [Cmdlet("Generate", "PrivateKey")]
    public class GeneratePrivateKey : BaseCmdlet
    {
        //[Parameter(Mandatory = true, Position = 0, HelpMessage = "TestNet or Main Bitcoin Network")]
        //public Network NetworkType { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "TestNet or Main Bitcoin Network")]
        public Network NetworkType { get; set; }

        protected override void BeginProcessing()
        {
            Core c = new Core();
            PrivateKey k = c.GeneratePrivateKey(NetworkType);
            WriteObject(k);
            base.BeginProcessing();
        }
    }
}
