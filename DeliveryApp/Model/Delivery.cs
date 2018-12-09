using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double OrginLong { get; set; }
        public double OrginLat { get; set; }
        public double DestLong { get; set; }
        public double DestLat { get; set; }
        /// <summary>
        ///  0= waiting for pickup
        ///  1= on the way
        ///  2= delivered
        /// </summary>
        /// <returns></returns>
        public int Status { get; set; }

        public static async Task<List<Delivery>> GetDleivery()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().ToListAsync();
            return deliveries;
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
           return await AzureHelper.SaveData<Delivery>(delivery);
        }
    }
}
