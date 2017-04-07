using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour {

    public string name;
    public Sprite sprite;
    public LayerType layerType;

    public TileBase() {
        name = "";
        sprite = new Sprite();
        layerType = LayerType.UNSET;
    }



}
