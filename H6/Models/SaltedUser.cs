﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SaltedUser
    {
        public int Id { get; set; }
        public string Salt { get; set; }
        public User User { get; set; }
    }
}
