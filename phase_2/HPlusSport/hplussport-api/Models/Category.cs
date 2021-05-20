using System.Collections.Generic;

namespace hplussport_api_models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }




    }
}