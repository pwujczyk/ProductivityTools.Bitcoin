using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinCore
{
    public class BitcoinDataSet
    {
        public string WIF { get; set; }
        public string PublicKey { get; set; }
        public string Hash { get; set; }
        public string Address { get; set; }
        public string ScriptPubKey { get; set; }

        public override string ToString()
        {
            Func<Expression<Func<BitcoinDataSet, string>>, string> f = s => String.Format($"{((s.Body) as MemberExpression).Member.Name}: {s.Compile().Invoke(this)}" + Environment.NewLine);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(f(x => x.WIF));
            stringBuilder.Append(f(x => x.PublicKey));
            stringBuilder.Append(f(x => x.Hash));
            stringBuilder.Append(f(x => x.Address));
            stringBuilder.Append(f(x => x.ScriptPubKey));
            return stringBuilder.ToString();
        }
    }
}
