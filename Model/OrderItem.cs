using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderItem
    {
        public string Type { get; set; }

        public string ItemName { get; set; }

        public string Material { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public double Cost => this.Price * this.Count;
    }
}
