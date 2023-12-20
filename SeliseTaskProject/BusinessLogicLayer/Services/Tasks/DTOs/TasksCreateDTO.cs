﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Tasks.DTOs
{
    public class TasksCreateDTO
    {
        
      

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
