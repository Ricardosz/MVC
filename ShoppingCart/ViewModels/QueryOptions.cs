using Newtonsoft.Json;
namespace ShoppingCart.ViewModels
{
    public class QueryOptions
    {
        public QueryOptions()
        {
            CurrentPage = 1;
            PageSize = 1;

            SortField = "Id";
            SortOrder = ViewModels.SortOrder.ASC.ToString();
        }

        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "sortField")]
        public string SortField { get; set; }

        [JsonProperty(PropertyName = "sortOrder")]
        public string SortOrder { get; set; }

        [JsonIgnore]
        public string Sort
        {
            get
            {
                return string.Format("{0} {1}",
                    SortField, SortOrder);
            }
        }
    }
}