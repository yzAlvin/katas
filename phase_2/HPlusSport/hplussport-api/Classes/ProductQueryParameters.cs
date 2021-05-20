namespace hplussport_api_classes
{
    public class ProductQueryParameters : QueryParameters
    {
        public string Sku { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string Name { get; set; }
        public string SearchTerm { get; set; }


    }
}