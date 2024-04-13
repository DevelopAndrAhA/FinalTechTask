using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TechDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
