using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryPerson
    {
        public string DeliveryId { get; set; }

        public static async Task<DeliveryPerson> GetDleiveryPerson(String DeliveryId)
        {
            DeliveryPerson deliveryPerson = new DeliveryPerson();
            deliveryPerson = (await AzureHelper.mobile.GetTable<DeliveryPerson>().Where(dp=>dp.DeliveryId== DeliveryId).ToListAsync()).FirstOrDefault();
            return deliveryPerson;
        }

    }
}
