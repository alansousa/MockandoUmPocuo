using System.Collections.Generic;

namespace Mockei.Entities
{
    public class CompoundProduct
    {
        public ICollection<SimpleProduct> SimpleProducts { get; set; } 
    }
}