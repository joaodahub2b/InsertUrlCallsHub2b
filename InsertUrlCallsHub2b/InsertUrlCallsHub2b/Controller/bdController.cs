using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertUrlCallsHub2b.Controller
{
    public class bdController
    {
        public static void Start()
        {
            using var ctx = new HubIntegrationConfigContext();
            //Inserir abaixo o mesmo Select usado na tela de StuckedCalls do Extension
            var urls = ctx.IntegrationConfigs.Where(x => x.Enabled == 1 && x.LastCall.Contains("03/2022") && x.Success == 0).ToList();

            ctx.SaveChanges();
            
            foreach (var url in urls)
            {
                Console.WriteLine(url.Id);
            }

            Delete(urls);
            Insert(urls);
        }

        public static void Delete(List<IntegrationConfig> urls)
        {
            using var ctx = new HubIntegrationConfigContext();
            foreach (var url in urls)
            {
                //Validar se esse remove estará deletando a URL trancada
                ctx.Remove(url);
                Console.WriteLine($"URL {url.Id} será removida");
                //ctx.SaveChanges();
            }
        }

        public static void Insert(List<IntegrationConfig> urls)
        {
            using var ctx = new HubIntegrationConfigContext();
            foreach (var url in urls)
            {
                //Validar se esse insert estará inserindo a URL correta
                ctx.IntegrationConfigs.Add(url);
                Console.WriteLine($"URL {url.Id} será inserida");
                //ctx.SaveChanges();
            }
        }
    }
}
