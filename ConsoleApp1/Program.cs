using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {

                ServiceHost svc = new ServiceHost(typeof(Service1));
                svc.Open();
                Console.WriteLine("START WCF");
                Console.ReadLine();


                svc.Close();
                Console.WriteLine("END WCF");
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: {0}", ex.Message);
                  
            }



        }
    }
}
