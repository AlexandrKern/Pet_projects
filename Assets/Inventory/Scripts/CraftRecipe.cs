using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftRecipe
{
    public int[] requaredItems;
    public int itemToCraft;

    public CraftRecipe(int itemToCraft, int[] requaredItems)
    {
        this.itemToCraft = itemToCraft;
        this.requaredItems = requaredItems;
    }
}
