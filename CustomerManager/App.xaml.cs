using Marten;
using System.Configuration;

namespace CustomerManager
{
    public partial class App
    {
        public App()
        {
            Store = DocumentStore.For(configure =>
            {
                configure.Connection(ConfigurationManager.ConnectionStrings["CustomerDb"].ConnectionString);

                // Can also configure this via attributes on properties on the objects themselves.
                configure.Schema.For<Customer>().ForeignKey<AccountManager>(c => c.AccountManagerId);
            });
        }

        public static IDocumentStore Store { get; private set; }
        
    }
}
