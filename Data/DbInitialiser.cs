using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(WebStoreDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
