using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Very simple inventory class so the player can have named items, which
// can be used by triggers etc. to check for keys
public class Inventory : MonoBehaviour
{
    public List<string> items;

    public void AddItem (string itemName)
    {
        if (!string.IsNullOrEmpty(itemName))
        {
            items.Add(itemName);
        }
    }

    public bool HasItem (string itemName, bool remove = false)
    {
        int index = items.IndexOf(itemName);
        if (index >= 0)
        {
            if (remove)
            {
                items.RemoveAt(index);
            }

            return true;
        }

        return false;
    }
}