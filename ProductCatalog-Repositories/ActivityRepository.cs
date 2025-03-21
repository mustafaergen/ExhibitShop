using Microsoft.EntityFrameworkCore;
using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Repositories.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly RepositoryContext _context;

        public ActivityRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task AddActivity(Activities activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Activities>> GetActivities(ActivityStatus activityStatus)
        {
            return await _context.Activities.Where(a => a.ActivityStatus == activityStatus).OrderByDescending(a => a.CreatedAt).Take(10).ToListAsync();
        }
    }
}
