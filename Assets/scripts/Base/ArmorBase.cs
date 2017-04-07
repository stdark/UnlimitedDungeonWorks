using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBase : ItemBase {
    public int armorClass;
    public ArmorType armorType;

    public ArmorBase()
    {
        armorClass = 0;
        armorType = ArmorType.UNSET;
    }
}
