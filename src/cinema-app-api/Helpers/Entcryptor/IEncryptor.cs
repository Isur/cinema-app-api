namespace cinema_app_api.Helpers
{
    public interface IEncryptor
    {
        public string Encrypt(string text);
        public string Decrypt(string code);
    }
}