﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Categorys
    {
        [Key]public int CategoryID { get; set; }
        public string category { get; set; }
    }
}
