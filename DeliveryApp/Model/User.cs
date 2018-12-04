using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async static Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                var user = (await AzureHelper.mobile.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user.Password == password)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            else
            {
                result = false;
            }
            return result;
        }

        public static async Task<bool> SignUp(string email, string password, string confirm)
        {
            var result = false;
            if (!string.IsNullOrEmpty(password))
            {
                if (password == confirm)
                {
                    User user = new User()
                    {
                        Email = email,
                        Password = password
                    };
                    await AzureHelper.mobile.GetTable<User>().InsertAsync(user);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
