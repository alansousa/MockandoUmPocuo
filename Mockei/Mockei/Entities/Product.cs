using System;

namespace Mockei.Entities
{
    public abstract class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}