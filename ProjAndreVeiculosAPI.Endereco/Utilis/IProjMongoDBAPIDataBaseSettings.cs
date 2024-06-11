namespace ProjAndreVeiculosAPIEndereco.Utilis
{
    public interface IProjMongoDBAPIDataBaseSettings
    {
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
