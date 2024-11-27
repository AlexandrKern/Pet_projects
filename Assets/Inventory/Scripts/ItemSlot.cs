using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    private Item _item;

    public void AddItem(Item item)
    {
        icon.sprite = item.icon;   
        _item = item;
    }

    public void UseItem()
    {
        if (_item != null)
        {
            _item.Use();
        }
    }

    public void DestrouySlot()
    {
        Destroy(gameObject);
    }
}
