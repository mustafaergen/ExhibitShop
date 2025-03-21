using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Services.Contracts;
using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepositoryManager _manager;

        public ActivityService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task AddActivity(Activities activity)
        {
            await _manager.ActivityRepository.AddActivity(activity);
            await _manager.SaveAsync();
        }


        public async Task<IEnumerable<Activities>> GetActivitiesByStatus(ActivityStatus activityStatus)
        {
            var activities = await _manager.ActivityRepository.GetActivities(activityStatus);
            return activities.Where(a => a.ActivityStatus == activityStatus).ToList(); 
        }


    }
}
