using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<Item> craftingRecipes = new List<Item>();


    public void OnStateItemUse(StatItemType statItemType,int amount)
    {
        Debug.Log("StateItem: " + statItemType + " amount: " + amount);
    }
}
