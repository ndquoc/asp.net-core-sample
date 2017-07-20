using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCms.DAL.Enums;

namespace TinyCms.DAL.Entities
{
    public class Job : EntityBase
    {
        public string JobCode { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public DateTime? ApplyBeforeDate { get; set; }

        public DateTime? PublishDate { get; set; }

        public string ContactPerson { get; set; }

        public JobStatus Status { get; set; }
    }
}
