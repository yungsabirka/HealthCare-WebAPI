using StackExchange.Redis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project.WebAPI.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTimeOffset.Parse(reader.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            }

            public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("O"));
            }
        }

        public T GetData<T>(string key)
        {
            var value = _cacheDb.StringGet(key);
            if (!value.IsNull)
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new DateTimeOffsetConverter());
                return JsonSerializer.Deserialize<T>(value, options);
            }
            return default;
        }

        public object RemoveData(string key)
        {
            var _exist = _cacheDb.KeyExists(key);

            if (_exist)
                return _cacheDb.KeyDelete(key);

            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expirationTimeSpan = expirationTime - DateTimeOffset.Now;
            return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expirationTimeSpan);

        }
    }
}
