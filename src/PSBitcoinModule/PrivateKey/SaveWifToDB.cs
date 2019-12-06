using BitcoinSimpleClientPSModule;
using PSBitcoinCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinModule.PrivateKey
{
    [Cmdlet("SaveWif", "ToDB")]
    public class SaveWifToDB : BaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string Wif { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }
        protected override void ProcessRecord()
        {
            Console.Write(Wif);
            Core c = new Core();
            c.SaveWifToDB(Wif, Name);
            base.ProcessRecord();
        }
    }
}
