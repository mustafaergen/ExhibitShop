using ProductCatolog_Core.Enums;
using ProductCatolog_Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Repositories.Contracts
{
    public interface IActivityRepository
    {
        Task AddActivity(Activities activity);
        Task<List<Activities>> GetActivities(ActivityStatus activityStatus);
    }
}
