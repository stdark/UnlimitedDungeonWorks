using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorObjectBase : TileBase {

    ExteriorObjectType exteriorObjectType;
    bool passability;
    public ExteriorObjectBase()
    {
        exteriorObjectType = ExteriorObjectType.UNSET;
        passability = false;
    }
}
