using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinCore
{
    public partial class Core
    {
        public string GeneratePublicAddress(string WIF)
        {
            Key k = Key.Parse(WIF);
            return k.PubKey.ToString();
        }


        public string GetAddressFromPublicKey(string publicKey, BitcoinSimpleClientObjects.Network network)
        {
            PubKey k = new PubKey(publicKey);
            var address= k.GetAddress(Mapper.Map<BitcoinSimpleClientObjects.Network, Network>(network));
            return address.ToString();
        }
    }
}
