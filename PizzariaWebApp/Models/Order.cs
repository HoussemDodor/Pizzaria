using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public int accountID { get; set; }
        public string deliveryAdress { get; set; }
        public string houseNumber { get; set; }
        public string houseNumberAddition { get; set; }
        public string city { get; set; }
        public DateTime dateOrderPlaced { get; set; }
        public string customerComment { get; set; }
        public bool takeAway { get; set; }
        public bool delivered { get; set; }
        List<Product> productsByThisOrder { get; set; }

        public Order(int ID, int accountID, string deliveryAdress, string houseNumber, string houseNumberAddition, string city, DateTime dateOrderPlaced, string customerComment, bool takeAway, bool delivered)
        {
            this.ID = ID;
            this.accountID = accountID;
            this.deliveryAdress = deliveryAdress;
            this.houseNumber = houseNumber;
            this.houseNumberAddition = houseNumberAddition;
            this.city = city;
            this.dateOrderPlaced = dateOrderPlaced;
            this.customerComment = customerComment;
            this.takeAway = takeAway;
            this.delivered = delivered;
        }
        public Order(int ID, int accountID, string deliveryAdress, string houseNumber, string city, DateTime dateOrderPlaced, string customerComment, bool takeAway, bool delivered)
        {
            this.ID = ID;
            this.accountID = accountID;
            this.deliveryAdress = deliveryAdress;
            this.houseNumber = houseNumber;
            this.city = city;
            this.dateOrderPlaced = dateOrderPlaced;
            this.customerComment = customerComment;
            this.takeAway = takeAway;
            this.delivered = delivered;
        }
        public Order(int accountID, string deliveryAdress, string houseNumber, string houseNumberAddition, string city, DateTime dateOrderPlaced, string customerComment, bool takeAway, bool delivered)
        {
            this.accountID = accountID;
            this.deliveryAdress = deliveryAdress;
            this.houseNumber = houseNumber;
            this.houseNumberAddition = houseNumberAddition;
            this.city = city;
            this.dateOrderPlaced = dateOrderPlaced;
            this.customerComment = customerComment;
            this.takeAway = takeAway;
            this.delivered = delivered;
        }
        public Order(int accountID, string deliveryAdress, string houseNumber, string city, DateTime dateOrderPlaced, string customerComment, bool takeAway, bool delivered)
        {
            this.accountID = accountID;
            this.deliveryAdress = deliveryAdress;
            this.houseNumber = houseNumber;
            this.city = city;
            this.dateOrderPlaced = dateOrderPlaced;
            this.customerComment = customerComment;
            this.takeAway = takeAway;
            this.delivered = delivered;
        }
    }
}
