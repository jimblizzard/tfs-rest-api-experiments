using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Helper
    {
        public static string ThisIsMyVSTS = "{https://MyTFSMachineName:8080/tfs}"; // for VSTS use "https://{yourAccount}.visualstudio.com";
        public static string ThisisMyPAT = "{myPAT}"; // For PAT creation, see https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate
        public static string ThisIsMyTPC = "/{MyTeamProjectCollection}";
        public static string ThisIsMyTP = "/{MyTeamProject}";
    }
}
