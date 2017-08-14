using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.CodeFirst
{
    public partial class test2
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int type { get; set; }
    }
}
