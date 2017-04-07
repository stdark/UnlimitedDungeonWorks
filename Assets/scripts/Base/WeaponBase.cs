using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : ItemBase {
    public WeaponType weaponType;
    public DamageType damageType;
    public int diceCount;
    public DiceType diceType;

    public WeaponBase()
    {
        weaponType = WeaponType.UNSET;
        damageType = DamageType.UNSET;
        diceCount = 0;
        diceType = DiceType.UNSET;
    }


}
