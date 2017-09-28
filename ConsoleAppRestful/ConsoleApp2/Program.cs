using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static string _apis = "/_apis";

        static void Main(string[] args)
        {
            // Three different API call samples, each in its own method. 
            // Uncomment the one you want to run. 
            // Yeah, pretty basic, but anyway . . .

            //GetProjects();
            //GetBuildsWithNoTags();
            //GetASpecificBuild(529);
        }

        private static async void GetProjects()
        {

            // Projects API reference: https://www.visualstudio.com/en-us/docs/integrate/api/tfs/projects

            string myRequest = "/projects";
            string apiVersion = "?api-version=2.0";

            string restCall = Helper.ThisIsMyVSTS + Helper.ThisIsMyTPC + _apis + myRequest + apiVersion;
            restCallHelper(restCall);
        }

        private static async void GetBuildsWithNoTags()
        {

            // Build API reference: https://www.visualstudio.com/en-us/docs/integrate/api/build/builds

            string myRequest = "/build/builds?tagfilters=&statusFilter=completed&$top=25";
            string apiVersion = "&api-version=2.0";

            string restCall = Helper.ThisIsMyVSTS + Helper.ThisIsMyTPC + Helper.ThisIsMyTP + _apis + myRequest + apiVersion;

            restCallHelper(restCall);
        }

        private static void GetASpecificBuild(int buildID)
        {

            // Build API reference: https://www.visualstudio.com/en-us/docs/integrate/api/build/builds

            string myRequestA = "/build/builds/";
            string myRequestB = "/timeline";
            string apiVersion = "?api-version=2.0";

            string restCall = Helper.ThisIsMyVSTS + Helper.ThisIsMyTPC + Helper.ThisIsMyTP + _apis +
                myRequestA + 
                buildID.ToString() + 
                myRequestB + 
                apiVersion; 

            restCallHelper(restCall); 
        }

        private async static void restCallHelper(string restCall)
        {
            try
            {
                var personalaccesstoken = Helper.ThisisMyPAT;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = client.GetAsync(restCall).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
