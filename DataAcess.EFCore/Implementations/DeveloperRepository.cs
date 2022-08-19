using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAcess.EFCore.Implementations
{
    public class DeveloperRepository : GenericRepository<Developer> ,IDeveloperRepository
    {
        private readonly DataContext context;

        public DeveloperRepository(DataContext context):base(context)
        {
            this.context = context;
        }
        public IEnumerable<Developer> GetPopularDevelopers(int count)
        {
            return context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        }
    }
    
}
