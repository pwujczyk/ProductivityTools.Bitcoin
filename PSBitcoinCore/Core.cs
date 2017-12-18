using AutoMapper;
using BitcoinSimpleClientObjects;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinClientCore
{
    public class Core
    {
        IMapper Mapper = new Mapper(AutoMapperConfiguration.Configuration);

        public string GenerateWIF(BitcoinSimpleClientObjects.Network network)
        {
            Key key = new Key();
            string wif = key.GetWif(Mapper.Map<BitcoinSimpleClientObjects.Network, NBitcoin.Network>(network)).ToString();
            return wif;
        }

        public PrivateKey GeneratePrivateKey(BitcoinSimpleClientObjects.Network network)
        {        
            Key key = new Key();
            PrivateKey result = new PrivateKey();
            result.WIF = key.GetWif(Mapper.Map<BitcoinSimpleClientObjects.Network, NBitcoin.Network>(network)).ToString();
            result.Decimal = PrivateKeyTools.GetPrivateDecimalKey(key);
            result.Binary = PrivateKeyTools.GetPrivateBinaryKey(key);
            return result;
        }

        //public void xx()
        //{
        //    GeneratePrivateKey(Network.TestNet);

        //    xx(Network.TestNet);
        //}

        //public void xx(Network network)
        //{
        //    string WIF = GenerateNewPrivateKeyAndGetWIF(network);
        //    var b1 = GenerateNewDataSet(network, WIF);
        //    Write(b1);
        //    var b2 = GenerateNewDataSet(network, WIF);
        //    Write(b2);
        //    var b4 = GenerateNewDataSet(network, WIF);
        //    Write(b4);
        //}

        //public void Write(BitcoinDataSet b)
        //{
        //    Console.WriteLine(b.ToString());

        //}

        //public string GenerateNewPrivateKeyAndGetWIF()
        //{
        //    return GenerateNewPrivateKeyAndGetWIF(Network.TestNet);
        ////}

        //public string GenerateNewPrivateKeyAndGetWIF(Network network)
        //{
        //    Key privateKey = new Key();
        //    var wif = privateKey.GetWif(network);
        //    return wif.ToString();

        //}


        private static BitcoinDataSet GenerateNewDataSet(NBitcoin.Network network, string wif)
        {
            BitcoinSecret privateKey = new BitcoinSecret(wif);
            BitcoinDataSet btds = new BitcoinDataSet();
            btds.WIF = privateKey.ToWif().ToString();
            btds.PublicKey = privateKey.PubKey.ToString();
            btds.Hash = privateKey.PubKey.Hash.ToString();
            btds.Address = privateKey.PubKey.GetAddress(network).ToString();
            btds.ScriptPubKey = privateKey.PubKey.GetAddress(network).ScriptPubKey.ToString();
            return btds;
        }
    }
}
