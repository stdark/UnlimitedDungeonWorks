using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour {
    public string name;
    public string desc;
    public ItemType type;

    public ItemBase()
    {
        name = "";
        desc = "";
        type = ItemType.UNSET;
    }
}
