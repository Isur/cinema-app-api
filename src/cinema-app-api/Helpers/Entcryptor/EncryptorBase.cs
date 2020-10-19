namespace cinema_app_api.Helpers
{
    public abstract class EncryptorBase
    {
        public abstract string Encrypt(string text);
        public abstract string Decrypt(string code);
    }
}