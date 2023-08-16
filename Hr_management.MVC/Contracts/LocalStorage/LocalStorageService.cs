using Hanssens.Net;

namespace Hr_management.MVC.Contracts
{
    public class LocalStorageService : ILocalStorageService
    {
        LocalStorage _storage;
        IConfiguration _configuration;
        public LocalStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = _configuration.GetSection("LocalStorageProjectName").Value,
            };
            _storage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist(); // save and sort storage key value
        }
    }
}
