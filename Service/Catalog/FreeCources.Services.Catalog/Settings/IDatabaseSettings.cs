namespace FreeCources.Services.Catalog.Settings
{
    internal interface IDatabaseSettings
    {
        public string CourceCollectionName { get; set; }
        public string CatagoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
