using System;
using System.Collections.Generic;
using System.Linq;
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
        public int Status { get; set; }

        public string DeliveryPersonId { get; set; }
        public static async Task<List<Delivery>> GetDleivery()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().Where(d=>d.Status!=2).ToListAsync();
            return deliveries;
        }
        public static async Task<List<Delivery>> GetDelivered()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Status == 2).ToListAsync();
            return deliveries;
        }

        public static async Task<List<Delivery>> GetDelivered(string UserID)
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Status == 2 && d.DeliveryPersonId== UserID).ToListAsync();
            return deliveries;
        }

        public static async Task<List<Delivery>> GetOnTheWayDelivery(string PersonId)
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Status == 1 && d.DeliveryPersonId== PersonId).ToListAsync();
            return deliveries;
        }

        public static async Task<List<Delivery>> GetWaitingForDelivery()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Status == 0).ToListAsync();
            return deliveries;
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
           return await AzureHelper.SaveData<Delivery>(delivery);
        }

        public static async Task<bool> PickedUpPackage(Delivery delivery, string PersonId)
        {
            try
            {
                delivery.Status = 1;
                delivery.DeliveryPersonId = PersonId;
                await AzureHelper.mobile.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> DeliveredPackage(Delivery delivery)
        {
            try
            {
                delivery.Status = 2;
                await AzureHelper.mobile.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> PickedUpPackage(string deliveryId, string PersonId)
        {
            try
            {
                var delivery = (await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Id == deliveryId).ToListAsync()).FirstOrDefault();
                delivery.Status = 1;
                delivery.DeliveryPersonId = PersonId;
                await AzureHelper.mobile.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<bool> DeliveredPackage(string deliveryId)
        {
            try
            {
                var delivery = (await AzureHelper.mobile.GetTable<Delivery>().Where(d => d.Id == deliveryId).ToListAsync()).FirstOrDefault();
                delivery.Status = 2;
                await AzureHelper.mobile.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }
    }
}
