using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : LoginModel
    {
        public int Id { get; set; }
       
        public Country Country { get; set; }
        public Area Area { get; set; }
    }
}
