using PSBitcoinClientCore;
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
        protected override void BeginProcessing()
        {
            Core c = new Core();
            string wif = c.GenerateWIF(NetworkType);
            WriteObject(wif);
            base.BeginProcessing();
        }
    }
}
