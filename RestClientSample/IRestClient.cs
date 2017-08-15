namespace RestClientSample
{
    public interface IRestClient<TClient>
    {
        TClient Client { get; set; }

        TClient GetClient(string url);
    }
}