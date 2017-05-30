using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.ViewModels
{
    public class CartItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartId")]
        public int CartId { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public int BookId { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "book")]
        public BookViewModel Book { get; set; }
    }
}