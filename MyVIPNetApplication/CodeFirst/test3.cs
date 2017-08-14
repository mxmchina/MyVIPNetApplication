using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.CodeFirst
{
    public partial class test3
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int type { get; set; }

        [StringLength(50)]
        public string content { get; set; }
    }
}
