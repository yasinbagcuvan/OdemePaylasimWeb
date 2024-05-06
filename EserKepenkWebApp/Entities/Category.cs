using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
