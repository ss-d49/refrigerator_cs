using System;

namespace refrigerator
{
    [Serializable()]
    public class foodItem
    {
        private String itemName;
        private DateTime expiryDate;

        public foodItem(String itemName, DateTime expiryDate)
        {
            this.itemName = itemName;
            this.expiryDate = expiryDate;
        }

        public String getItemName()
        {
            return this.itemName;
        }

        public DateTime getExpiryDate()
        {
            return this.expiryDate;
        }

        public void setItemName()
        {
            this.itemName = itemName;
        }

        public void setExpiryDate()
        {
            this.expiryDate = expiryDate;
        }
    }
}