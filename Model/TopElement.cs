﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TopElement:IItem
    {
        public string Name { get; set; }
        public List<Material> Materials;
    }
}
