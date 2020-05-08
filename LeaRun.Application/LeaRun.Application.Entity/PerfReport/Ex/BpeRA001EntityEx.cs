using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.PerfReport
{
    public partial class BpeRA001Entity
    {
        /// <summary>
        /// 战略主题
        /// </summary>
        [NotMapped]
        public string ZTMC { get; set; }
    }
}
