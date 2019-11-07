using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CrmServiceClient("AuthType=Office365;Url=https://org2837659f.crm4.dynamics.com;"
                + "Username=danj@CRM097147.OnMicrosoft.com;Password=TechLabs1;");

            Entity en = new Entity("contact");
            // service.Create(new Entity("contact")
            //{
            //    ["firstname"] = "Mohammed",
            //    ["lastname"] = "Salah",
            //    ["telephone1"] = "01112754765",
            //    ["jobtitle"] = "ASP.NET Developer",
            //    ["emailaddress1"] = "MohammedSlah19@yahoo.com",

            //});

            Console.WriteLine("Enter Your Email");
            string Email = Console.ReadLine();
            string Emailformte = "{ emailaddress1 = " + Email + " }";
            var query = (from contact in new OrganizationServiceContext(service).CreateQuery("contact")
                               select new
                               {
                                   emailaddress1 = contact["emailaddress1"]

                               }).ToList();

            bool exits = false;
            foreach (var item in query)
            {
                if (item.ToString() == Emailformte)
                {
                    exits = true;
                    break;
                 }

            }

            if (exits == true)
            {
                Console.WriteLine("this email is exist");

            }

            else
            {
                service.Create(new Entity("contact")
                {

                    ["emailaddress1"] = Email,
                    ["firstname"] = "Mohammed",
                    ["lastname"] = "Salah",
                    ["telephone1"] = "01112754765",

                });

                Console.WriteLine("Added successfully");

            }

        }
    }
}
