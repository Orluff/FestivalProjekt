﻿using System;
using System.ComponentModel.DataAnnotations;

public class ShiftCategoryDTO
{
    public int category_id { get; set; }

    public string categoryName { get; set; }

    public string? description { get; set; }

    public string area { get; set; }
}

