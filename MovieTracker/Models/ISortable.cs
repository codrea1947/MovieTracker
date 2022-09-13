namespace MovieTracker.Models
{
    public interface ISortable : IEntity
    {
        public int SortIndex { get; set; }
    }
}
