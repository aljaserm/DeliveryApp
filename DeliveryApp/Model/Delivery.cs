using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Delivery
    {
        public static async Task<List<Delivery>> GetDleivery()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().ToListAsync();
            return deliveries;
        }

    }
}
