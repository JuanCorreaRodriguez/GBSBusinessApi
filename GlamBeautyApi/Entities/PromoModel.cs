namespace GBSApi.Entities
{
    public class PromoModel
    {
        public int PromoId { get; set; }
        public int Count { get; set; } = 0;
        public DateTime CreateAt { get; set; } = new DateTime();
        public DateTime From { get; set; } = new DateTime();
        public DateTime To { get; set; } = new DateTime();
        public string Desc { get; set; } = string.Empty;
        public decimal DiscountPercentage {  get; set; } = 0m;
        public decimal DiscountAmount {  get; set; } = 0m;
        public int MaxCount { get; set; } = 0;
        public string Name {  get; set; } = string.Empty;
        public string Sku {  get; set; } = string.Empty;
    }
}
