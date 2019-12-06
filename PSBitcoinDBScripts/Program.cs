using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSBitcoinDBScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverName = @".\sql2014";
            string dbName = "BTCTest";

            DBUpHelper.DBUp dBUp = new DBUpHelper.DBUp("btt");
            Assembly assembly = Assembly.GetExecutingAssembly();
            dBUp.PerformUpdate(serverName, dbName, assembly, true);
        }
    }
}
