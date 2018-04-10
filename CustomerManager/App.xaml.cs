using Marten;
using System.Configuration;

namespace CustomerManager
{
    public partial class App
    {
        public App()
        {
            Store = DocumentStore.For(ConfigurationManager.ConnectionStrings["CustomerDb"].ConnectionString);
        }

        public static IDocumentStore Store { get; private set; }
        
    }
}
