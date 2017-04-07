using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorTileBase : TileBase {

    public ExteriorTileType exteriorTileType;
    public int speedMod;
    public ExteriorTileBase()
    {
        exteriorTileType = ExteriorTileType.UNSET;
        speedMod = 1;
    }
}
