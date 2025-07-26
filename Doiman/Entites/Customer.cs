﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Entites
{
    public class Customer:BaseEntity<int>
    {
        
     
            public string Name { get; set; }
            public string Email { get; set; }

            public ICollection<Order> Orders { get; set; }
        
    }
}
