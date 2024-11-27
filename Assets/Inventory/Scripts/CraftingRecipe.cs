using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftingRecipe : Item
{
    public Item result;
    public Ingredient[] ingredients;


    private bool CanCraft()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            bool containsCurrentIngridients = Inventory.instance.Contains(ingredient.Item,ingredient.amount);
            if (!containsCurrentIngridients)
            {
                return false;
            }
        }
        return true;
       
    }

    private void RemoveIngridientsFromInventory()
    {
        foreach (Ingredient ingredient in ingredients)
        {
            Inventory.instance.RemoveItems(ingredient.Item, ingredient.amount);
        }
    }

    public override void Use()
    {
        if (CanCraft())
        {
            RemoveIngridientsFromInventory();
            Inventory.instance.AddItem(result);
            PlayerController.Instance.bulletTypes.Add((BulletType)result);
            Debug.Log("Ты создал " + result.name);
        }
        else
        {
            Debug.Log("Не хватает ингридиентов " + result.name);
        }


    }

    [Serializable]
    public class Ingredient
    {
        public Item Item;
        public int amount;
    }
}
