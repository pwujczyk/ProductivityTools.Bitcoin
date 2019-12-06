using BitcoinSimpleClientPSModule;
using PSBitcoinCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinModule
{
    [Cmdlet("GetPublicKey", "FromPrivate")]
    public class GetPublicKeyFromPrivate : BaseCmdlet
    {
        [Parameter(ValueFromPipeline =true)]
        public string WIF { get; set; }

        protected override void BeginProcessing()
        {
            Core c = new Core();
            string publicKey = c.GeneratePublicAddress(this.WIF);
            WriteObject(publicKey);
            base.BeginProcessing();
        }
    }
}
