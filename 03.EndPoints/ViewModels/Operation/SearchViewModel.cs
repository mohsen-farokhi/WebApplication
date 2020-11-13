namespace ViewModels.Operation
{
    public class SearchViewModel : ViewDataRequest
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
