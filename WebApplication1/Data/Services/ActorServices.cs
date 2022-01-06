using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmy.Data.Base;
using Filmy.Models;

namespace Filmy.Data.Services
{
    public class ActorServices : EntityBaseRepository<Actor>, IActorServices
    {
            public ActorServices (AppDbContext context) : base(context)
            {
            }
       }
}
