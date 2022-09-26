using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dragger : ComponentBase
{
    public override string Name { get => "Dragger"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/cursor"); }

    public override bool CanPlace(Vector3Int at)
    {
        return false;
    }
}
