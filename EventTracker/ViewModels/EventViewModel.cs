namespace EventTracker.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string FormattedDate { get; set; } = string.Empty;
        public bool IsPinned { get; internal set; }
    }
}
