namespace cinema_app_api.Helpers
{
    public class Ceasar : EncryptorBase
    {
        private const int SHIFT = 1;
        private const int ALPHABET_LENGTH = 26;
        public override string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string code = "";
            foreach (char character in text)
            {
                code = $"{code}{_code(character, ALPHABET_LENGTH - SHIFT)}";
            }
            return code;
        }

        public override string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string code = "";
            foreach (char character in text)
            {
                code = $"{code}{_code(character, SHIFT)}";
            }
            return code;
        }

        private char _code(char character, int shift)
        {
            if (character > 'a' + ALPHABET_LENGTH || character < 'A') return character;
            char firstChar = char.IsUpper(character) ? 'A' : 'a';
            int newCode = (character + shift - firstChar) % ALPHABET_LENGTH + firstChar;
            return (char)newCode;
        }
    }
}