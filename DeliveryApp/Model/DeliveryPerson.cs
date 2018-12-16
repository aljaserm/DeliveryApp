using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryPerson
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<DeliveryPerson> GetDleiveryPerson(String DeliveryId)
        {
            DeliveryPerson deliveryPerson = new DeliveryPerson();
            deliveryPerson = (await AzureHelper.mobile.GetTable<DeliveryPerson>().Where(dp=>dp.Id== DeliveryId).ToListAsync()).FirstOrDefault();
            return deliveryPerson;
        }
        public async static Task<string> Login(string email, string password)
        {
            //bool result = false;
            string UserId=string.Empty;

            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
            {
                var user = (await AzureHelper.mobile.GetTable<DeliveryPerson>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        UserId = user.Id;
                    }
                    else
                    {
                        UserId = string.Empty;
                    }

                }
                else
                {
                    UserId = string.Empty;
                }

            }
            else
            {
                UserId = string.Empty;
            }
            return UserId;
        }

        public static async Task<bool> SignUp(string email, string password, string confirm)
        {
            var result = false;
            if (!string.IsNullOrEmpty(password))
            {
                if (password == confirm)
                {
                    DeliveryPerson deliveryPerson = new DeliveryPerson()
                    {
                        Email = email,
                        Password = password
                    };
                    //await AzureHelper.mobile.GetTable<User>().InsertAsync(user);
                    await AzureHelper.SaveData(deliveryPerson);
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
