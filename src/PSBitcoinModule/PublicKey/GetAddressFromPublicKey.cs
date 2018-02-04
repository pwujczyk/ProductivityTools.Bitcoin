using BitcoinSimpleClientObjects;
using BitcoinSimpleClientPSModule;
using PSBitcoinCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinModule.PublicKey
{
    [Cmdlet("GetAddress", "FromPublicKey")]
    public class GetAddressFromPublicKey : BaseCmdlet
    {

        [Parameter(Mandatory =true)]
        public string PublicKey { get; set; }

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "TestNet or Main Bitcoin Network")]
        public Network NetworkType { get; set; }

        protected override void BeginProcessing()
        {
            Core c = new Core();
            string publicKey = c.GetAddressFromPublicKey(this.PublicKey, NetworkType);
            WriteObject(publicKey);
            base.BeginProcessing();
        }
    }
}
