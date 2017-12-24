using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinClientCore
{
    static internal class PrivateKeyTools
    {
        internal static string GetPrivateDecimalKey(Key privateKey)
        {
            FieldInfo[] fields = typeof(Key).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var eckeyfield = fields.Single(x => x.Name == "_ECKey");
            var eckey = eckeyfield.GetValue(privateKey);
            var privateKeyInternal = eckey.GetType().GetProperty("PrivateKey").GetValue(eckey);
            var privateKeyDecimal = privateKeyInternal.GetType().GetProperty("D").GetValue(privateKeyInternal);
            var resut = privateKeyDecimal.ToString();
            return resut;
        }

        internal static string GetPrivateBinaryKey(Key privateKey)
        {
            string decimalKey = GetPrivateDecimalKey(privateKey);
            int[] values = decimalKey.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            var r = LargeNumberOperations.ConvertDecimalCharArrayToBinaryCharArray(values);
            return String.Join("", r);
        }
    }
}
