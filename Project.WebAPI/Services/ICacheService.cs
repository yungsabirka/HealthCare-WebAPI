namespace Project.WebAPI.Services
{
    public interface ICacheService
    {
        T GetData<T>(string key);

        bool SetData<T>(string key, T valie, DateTimeOffset expirationTime);

        object RemoveData(string key);
    }
}
