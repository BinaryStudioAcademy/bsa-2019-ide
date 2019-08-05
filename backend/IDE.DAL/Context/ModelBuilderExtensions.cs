using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            // Add Fluent API configuration here
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Add database seed logic here
        }
    }
}
