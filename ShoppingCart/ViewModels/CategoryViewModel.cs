using Newtonsoft.Json;

namespace ShoppingCart.ViewModels
{
    public class CategoryViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}