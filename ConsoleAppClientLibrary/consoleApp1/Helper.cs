using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleApp1
{
    public class Helper
    {
        public static string ThisIsMyVSTS = "{https://MyTFSMachineName:8080/tfs/DefaultCollection}"; // for VSTS use "https://{yourAccount}.visualstudio.com";
        public static string ThisIsMyPAT = "{myPAT}"; // For PAT creation, see https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate
    }
}
