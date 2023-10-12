namespace RequestResponse
{
    public class GenericFilterRequest
    {
        public int page { get; set; }
        public int quantity { get; set; }
        public List<ItemFilter> Filters { get; set; } = new List<ItemFilter>();
    }
}