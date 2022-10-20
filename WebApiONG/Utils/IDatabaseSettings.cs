namespace WebApiONG.Utils
{
    public interface IDatabaseSettings
    {
        string AnimalCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
