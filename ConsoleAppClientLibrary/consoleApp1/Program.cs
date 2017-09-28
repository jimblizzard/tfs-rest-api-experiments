using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using System.Collections.Generic;

// This sample code use the client libraries instead of making direct rest api calls.

    // You'll need to grab a couple of nuget packages 
//      Microsoft.VisualStudio.Services.Client
//      Microsoft.TeamFoundationServer.Client

// Here are some other client library samples: https://docs.microsoft.com/en-us/vsts/integrate/get-started/client-libraries/samples 

namespace consoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri accountUri = new Uri(Helper.ThisIsMyVSTS);  
            String personalAccessToken = Helper.ThisIsMyPAT; 
            var workItemIds = new List<int>(); 
            workItemIds.Add(1744);      // this is a random list of work item ids in the tpc 
            workItemIds.Add(1665);
            workItemIds.Add(29);

            // Create a connection to the account
            VssConnection connection = new VssConnection(accountUri, new VssBasicCredential(string.Empty, personalAccessToken));

            // Get an instance of the work item tracking client
            WorkItemTrackingHttpClient witClient = connection.GetClient<WorkItemTrackingHttpClient>();

            try
            {
                foreach (var wID in workItemIds)
                {

                    Console.WriteLine("*****************************");
                    Console.WriteLine("*****************************");
                    Console.WriteLine("*** WORK ITEM: {0} *******", wID);
                    Console.WriteLine("*****************************");
                    Console.WriteLine("*****************************");


                    // Get the specified work item
                    WorkItem workitem = witClient.GetWorkItemAsync(wID).Result;

                    // Output the work item's field values
                    foreach (var field in workitem.Fields)
                    {
                        Console.WriteLine("  {0}: {1}", field.Key, field.Value);
                    }

                    Console.WriteLine();
                    Console.WriteLine();

                }
            }
            catch (AggregateException aex)
            {
                VssServiceException vssex = aex.InnerException as VssServiceException;
                if (vssex != null)
                {
                    Console.WriteLine(vssex.Message);
                }
            }
        }
    }
}