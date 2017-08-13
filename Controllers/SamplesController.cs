using System.Collections.Generic;
using System.Linq;
using FTDNA_Coding_Task.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTDNA_Coding_Task.Controllers
{
    [Route("api/[controller]")]
    public class SamplesController : Controller
    {
        public IEnumerable<Sample> Get()
        {
            using (var context = new FTDNAContext())
            {
                return context.Samples
                    .Include(sample => sample.Status)
                    .Include(sample => sample.User)
                    .ToArray();
            }
        }
    }
}
