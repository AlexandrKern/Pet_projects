using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCillect : MonoBehaviour
{
    [SerializeField] private Item _item;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(_item);
            Destroy(gameObject);
        }
    }
}
