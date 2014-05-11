using Microsoft.Owin.Hosting;
using System;

namespace DevStore.Tdc.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Serviço ouvindo no endereço: http://localhost:9000/");
                Console.ReadLine();
            }
        }
    }
}
