using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Model
{
   public class AzureHelper
    {
        public static MobileServiceClient mobile = new MobileServiceClient("https://delvieryapplication.azurewebsites.net");

    }
}
