﻿using System;
using System.ComponentModel.DataAnnotations;

public class ShiftCategoryDTO
{
    public int category_id { get; set; }

    public string categoryName { get; set; } = String.Empty;

    public string? description { get; set; } = String.Empty;

    public string area { get; set; } = String.Empty;
}

