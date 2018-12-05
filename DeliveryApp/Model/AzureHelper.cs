using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
   public class AzureHelper
    {
        public static MobileServiceClient mobile = new MobileServiceClient("https://delvieryapplication.azurewebsites.net");

        public static async Task<bool> SaveData<T>(T SavedObject)
        {
            try
            {
                await mobile.GetTable<T>().InsertAsync(SavedObject);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
