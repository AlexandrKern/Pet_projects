using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    new public string name = "Defulat name";
    public Sprite icon = null;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
