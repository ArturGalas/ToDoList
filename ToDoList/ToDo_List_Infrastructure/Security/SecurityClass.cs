using System.Security.Cryptography;
using System.Text;

namespace ToDo_List_Infrastructure.Security
{
    public static class SecurityClass
    {
        private static string salt = "BofVxkJitzTMYIy1TKCfmD8ZZJcJ5emTXC90cZfh0Qt4YJA+8ghe" +
            "o6liO5+4qTTgKUp7KDo/0IAveGfZhKSfBlRY6iSG8Q3lYFdvubdpPVJCiTj4bHVFg3Cl+ks1Z/A++bH8gQ" +
            "UEGJqeM/dUD1jMPECj8sJlSDf05vlTn13JIELEQVxYBNe3Xs936a6VdnR7S+DcMPPuCIPXdU2AXuPMh4J2j2AeGi0" +
            "ms8e/sv7zyFyY8XCbclJ+Q+5OytpcBENDU8X1M9KC67Fv7SGM7mdO/abmcoC5gNp7yqYLhRlKslvWCglvNlBuXPLzV6wr7K037hfIJ75YX6qT1tj6dnDOmw==";
        public static string HashPassword(string password) 
        { 
            SHA256 hash = SHA256.Create();
            var passwordbyte = Encoding.UTF8.GetBytes(string.Concat(salt,password));
            var hashedpassword = hash.ComputeHash(passwordbyte);

            return Convert.ToBase64String(hashedpassword);
        }
        public static bool ComparePassword(string password, string dbPassword)
        {
            var hashedpassword = HashPassword(password);
            return hashedpassword == dbPassword;
        }
    }
}
