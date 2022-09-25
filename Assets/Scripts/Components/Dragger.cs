using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dragger : ComponentBase
{
    public override bool CanPlace(Vector3Int at)
    {
        return false;
    }
}
