﻿namespace ProductsManagement.API.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ProductCount { get; set; }
}