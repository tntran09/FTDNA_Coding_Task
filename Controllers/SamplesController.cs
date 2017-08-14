using System;
using System.Collections.Generic;
using System.Linq;
using FTDNA_Coding_Task.Data;
using FTDNA_Coding_Task.Models;
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

        [Route("search")]
        [HttpPost]
        public IEnumerable<Sample> Search([FromBody] SampleSearchModel model)
        {
            using (var context = new FTDNAContext())
            {
                IEnumerable<Sample> result = context.Samples
                    .Include(sample => sample.Status)
                    .Include(sample => sample.User);

                if (model.Status.HasValue)
                {
                    result = result.Where(sample => sample.StatusId == model.Status);
                }

                if (!string.IsNullOrEmpty(model.Name))
                {
                    result = result.Where(sample => sample.User.FirstName.Contains(model.Name) || sample.User.LastName.Contains(model.Name));
                }

                return result.ToArray();
            }
        }

        [Route("create")]
        [HttpPost]
        public bool Create([FromBody] CreateSampleModel model)
        {
            using (var context = new FTDNAContext())
            {
                var status = context.Statuses.FirstOrDefault(s => s.StatusName == model.Status);
                var user = context.Users.FirstOrDefault(u => u.FirstName == model.FirstName && u.LastName == model.LastName);
                
                if (status == null)
                {
                    status = new Status() { StatusName = model.Status };
                    context.Statuses.Add(status);
                }

                if (user == null)
                {
                    user = new User() { FirstName = model.FirstName, LastName = model.LastName };
                    context.Users.Add(user);
                }

                context.SaveChanges();

                context.Add(new Sample()
                {
                    BarCode = model.Barcode,
                    CreatedAt = DateTime.Now,
                    StatusId = status.StatusId,
                    CreatedBy = user.UserId
                });

                return true;
            }
        }
    }
}
