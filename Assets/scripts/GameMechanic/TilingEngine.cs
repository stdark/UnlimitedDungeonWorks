using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingEngine : MonoBehaviour {

    public List<TileBase> TileSprites;
    public Vector2 MapSize;
    public Sprite DefaultSprite;
    public GameObject TileContainerPrefab;
    public GameObject TilePrefab;
    public Vector2 CurrentPos;
    public Vector2 ViewportSize;

    private TileBase[,] _map;
    private GameObject controller;
    private GameObject _tileContainer;
    private List<GameObject> _tiles = new List<GameObject>();

    private TileBase FindTile(TileType tile)
    {
        foreach (TileBase tileSprite in TileSprites)
        {
            if (tileSprite.tileType == tile) return tileSprite;
        }
        return null;
    }

    private void DefaultTiles()
    {
        for (var y = 0; y < MapSize.y - 1; y++)
        {
            for (var x = 0; x < MapSize.x - 1; x++)
            {
                _map[x, y] = new TileBase("unset", DefaultSprite, LayerType.UNSET, TileType.UNSET, 1, true);
            }
        }
    }

    private void SetTiles()
    {
        var index = 0;
        for (var y = 0; y < MapSize.y - 1; y++)
        {
            for (var x = 0; x < MapSize.x - 1; x++)
            {
                _map[x, y] = new TileBase(TileSprites[index].name, TileSprites[index].sprite, TileSprites[index].layerType, TileSprites[index].tileType, TileSprites[index].speedMod, TileSprites[index].passability);
                index++;
                if (index > TileSprites.Count - 1) index = 0;
            }
        }
    }

}
