using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _inventoryTab;
    [SerializeField] private GameObject _craftingTab;
    [SerializeField] private GameObject _inventorySlotPrefab;
    [SerializeField] private Transform _inventoryItemTransform;
    [SerializeField] private Transform _craftingItemTransform;

    private List<ItemSlot> itemSlots = new List<ItemSlot>();

    private bool _isActivInventiryPanel;
    private bool _isActivInventiry;

    private void Start()
    {
        _isActivInventiry = true;
        _isActivInventiryPanel = false;
        _inventoryPanel.SetActive(_isActivInventiryPanel);
        _inventoryTab.SetActive(_isActivInventiry);

        Inventory.instance.onItemChange += UpdateInventoryUi;
        SetUpCraftingRecipe();
        UpdateInventoryUi();
    }

    public void ToggleInventory()
    {
        _isActivInventiryPanel = !_isActivInventiryPanel;
        _inventoryPanel.SetActive(_isActivInventiryPanel);
    }

    public void ToggleInventoryAndCrafting()
    {
        _isActivInventiry = !_isActivInventiry;
        _inventoryTab.SetActive(_isActivInventiry);
        _craftingTab.SetActive(!_isActivInventiry);
    }

    public void SetUpCraftingRecipe()
    {
        List<Item> craftingRecipes = GameManager.instance.craftingRecipes;

        foreach (Item resipe in craftingRecipes)
        {
            GameObject GO = Instantiate(_inventorySlotPrefab, _craftingItemTransform);
            ItemSlot itemSlot = GO.GetComponent<ItemSlot>();
            itemSlot.AddItem(resipe);
        }
    }
   
    private void UpdateInventoryUi()
    {
        int currentItemCount = Inventory.instance.inventoryItemList.Count;

        if (currentItemCount > itemSlots.Count)
        {
            AddItemSlots(currentItemCount);
        }

        for (int i = 0; i < itemSlots.Count; i++)
        {
            if(i < currentItemCount)
            {
                itemSlots[i].AddItem(Inventory.instance.inventoryItemList[i]);
            }
            else
            {
                itemSlots[i].DestrouySlot();
                itemSlots.RemoveAt(i);
            }
        }
    }

    private void AddItemSlots(int currentItemCount)
    {
        int amount = currentItemCount - itemSlots.Count;

        for (int i = 0; i < amount; i++)
        {
            GameObject GO = Instantiate(_inventorySlotPrefab, _inventoryItemTransform);
            ItemSlot newItemSlot = GO.GetComponent<ItemSlot>();
            itemSlots.Add(newItemSlot);
        }
    }

}
