using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UIElements;
using System.Collections.Concurrent;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        InventoryItem result = LinearSearch("Sword");

        if (result != null)
        {
            Debug.Log("Found: " + result.itemName);
        }
        else
        {
            Debug.Log("Item not found");
        }
        InventoryItem result2 = BinarySearch(2);

        if (result2 != null)
        {
            Debug.Log("Binary Search Found: " + result2.itemName);
        }
        else
        {
            Debug.Log("Item not found");
        }
        QuickSort(0, inventory.Count - 1);

        foreach (InventoryItem item in inventory)
        {
            Debug.Log(item.itemName + " - Value: " + item.value);
        }
    }
    public InventoryItem LinearSearch(string searchName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.itemName == searchName)
            {
                return item;
            }
        }

        return null;
    }
    public InventoryItem BinarySearch(int searchID)
    {
        inventory.Sort((a, b) => a.ID.CompareTo(b.ID));

        int left = 0;
        int right = inventory.Count;

        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (inventory[middle].ID == searchID)
            {
                return inventory[middle];
            }
            else if (inventory[middle].ID < searchID)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return null;
    }
    public void QuickSort(int low, int high)
    {
        if (low < high)
        {
            int pivot =  Partition(low, high);

            QuickSort(low, pivot - 1);
            QuickSort(pivot + 1, high);
        }
    }

    int Partition(int low, int high)
    {
        int pivot = inventory[high].value;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (inventory[j].value <= pivot)
            {
                i++;

                InventoryItem temp = inventory[i];
                inventory[i] = inventory[j];
                inventory[j] = temp;
            }
        }

        InventoryItem temp2 = inventory[i + 1];
        inventory[i + 1] = inventory[high];
        inventory[high] = temp2;

        return i + 1;
    }


}
