using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour {

    public string name;
    public Sprite sprite;
    public LayerType layerType;
    public TileType tileType;
    public bool passability;
    public int speedMod;

    public TileBase() {
        name = "";
        sprite = new Sprite();
        layerType = LayerType.UNSET;
        tileType = TileType.UNSET;
        passability = true;
        speedMod = 1;
    }
    public TileBase(string n, Sprite sp, LayerType l, TileType tt, int spd, bool p)
    {
        name = n;
        sprite = sp;
        layerType = l;
        tileType = tt;
        speedMod = spd;
        passability = p;
    }



}
