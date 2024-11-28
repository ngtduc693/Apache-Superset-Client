using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupersetClientBase.Interfaces
{
    internal interface ISupersetClient
    {
        Task<string> GetDashboardsAsync();
        Task<string> GetChartsAsync();
        Task<string> ExecuteSqlAsync(string query);
    }
}
