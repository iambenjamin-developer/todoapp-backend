﻿using System.Collections.Generic;

namespace WebApi.Models
{
    public class UpdateRangeToDoItemsDto
    {
        public List<int> ToDoItemIds { get; set; }
        public bool MarkAsCompleted { get; set; }
    }
}
