using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.EFCore.Implementations
{
    public class UnitOFWork : IUnitOFWork
    {
        private readonly DataContext context;

        public UnitOFWork(DataContext context)
        {
            this.context = context;
            Developers = new DeveloperRepository(context);
            Projects = new ProjectRepository(context);
        }
        public IDeveloperRepository Developers { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public int Complete()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
