using System;
using System.Collections.Generic;

public interface ICheckout
{
    void Scan(string item);
    int GetTotal();
}

public class Item
{
    public Item(string sku, int price, int specialPrice = 0, int specialCount = 0)
    {
        this.Sku = sku;
        this.Price = price;
        this.SpecialPrice = specialPrice;
        this.SpecialCount = specialCount;
    }

    public string Sku;
    public int Price;
    public int SpecialPrice;
    public int SpecialCount;
    public int getDiscountedPrice(int itemCount)
    {
        try
        {
            int individualItems = itemCount;
            int specialItemCount = 0;
            if (this.SpecialCount > 0)
            {
                individualItems = itemCount % this.SpecialCount;
                specialItemCount = (itemCount - individualItems) / this.SpecialCount;
            }

            return (individualItems * this.Price) + (specialItemCount * this.SpecialPrice);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }
    }
}

public class Checkout : ICheckout
{
    public List<Item> Items;
    public List<Item> ScannedItems;
    public Checkout()
    {
        this.Items = new List<Item>();
        this.ScannedItems = new List<Item>();
    }

    public void Scan(string item)
    {
        if (this.Items == null || this.Items.Count == 0)
        {
            return;
        }

        for (int i = 0; i < this.Items.Count; i++)
        {
            Item currentItem = this.Items[i];
            if (currentItem != null && currentItem.Sku == item)
            {
                this.ScannedItems.Add(currentItem);
                return;
            }
        }
    }

    public int GetTotal()
    {
        int totalPrice = 0;
        if (this.ScannedItems == null || this.ScannedItems.Count == 0)
        {
            return totalPrice;
        }

        // Get the distinct SKUs from scanned items.   ====>>  ["A", "B", "C"]
        List<Item> distinctSkus = this.getDistinctItems();
        for (int i = 0; i < distinctSkus.Count; i++)
        {
            Item currentItem = distinctSkus[i];
            int currentSkuCount = getCountForSku(currentItem.Sku);
            totalPrice += currentItem.getDiscountedPrice(currentSkuCount);
        }

        return totalPrice;
    }

    public List<Item> getDistinctItems()
    {
        // initialise the list of distinct SKUs
        List<Item> distinctItems = new List<Item>();
        // null check, return empty list if invalid
        if (this.ScannedItems == null || this.ScannedItems.Count == 0)
        {
            return distinctItems;
        }

        // iterate the list and insert distinct SKUs
        for (int i = 0; i < this.ScannedItems.Count; i++)
        {
            Item scannedItem = this.ScannedItems[i];
            if (!distinctItems.Contains(scannedItem))
            {
                distinctItems.Add(scannedItem);
            }
        }

        return distinctItems;
    }

    public int getCountForSku(string sku)
    {
        int skuCount = 0;
        // null check, return empty list if invalid
        if (this.ScannedItems == null || this.ScannedItems.Count == 0)
        {
            return skuCount;
        }

        // iterate the list and insert distinct SKUs
        for (int i = 0; i < this.ScannedItems.Count; i++)
        {
            Item scannedItem = this.ScannedItems[i];
            if (scannedItem.Sku == sku)
            {
                ++skuCount;
            }
        }

        return skuCount;
    }

    public void addItem(Item item)
    {
        this.Items.Add(item);
    }
}