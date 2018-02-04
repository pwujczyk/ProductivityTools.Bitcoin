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
    [Cmdlet("Generate", "WIF")]
    public class GenerateWif : BaseCmdlet
    {

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "TestNet or Main Bitcoin Network")]
        public Network NetworkType { get; set; }


        protected override void BeginProcessing()
        {
            Core c = new Core();
            string wif = c.GenerateWIF(NetworkType);
            WriteObject(wif);
            base.BeginProcessing();
        }
    }
}
