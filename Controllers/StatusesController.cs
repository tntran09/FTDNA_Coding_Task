using FTDNA_Coding_Task.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FTDNA_Coding_Task.Controllers
{
    [Route("api/[controller]")]
    public class StatusesController
    {
        public IEnumerable<Status> Get()
        {
            using (var context = new FTDNAContext())
            {
                return context.Statuses.ToArray();
            }
        }

    }
}
