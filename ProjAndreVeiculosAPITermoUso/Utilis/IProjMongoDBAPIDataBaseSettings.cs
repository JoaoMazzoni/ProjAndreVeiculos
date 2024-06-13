namespace ProjAndreVeiculosAPITermoUso.Utilis
{
    public interface IProjMongoDBAPIDataBaseSettings
    {
        string TermoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
