﻿namespace WebApiONG.Utils
{
    public interface IDatabaseSettings
    {
        string AnimalCollectionName { get; set; }
        string PersonCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
