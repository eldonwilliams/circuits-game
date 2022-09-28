using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Wire : ComponentBase
{
    public override string Name { get => "Wire"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/wire-image"); }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.sprite = Resources.Load<Sprite>("Components/Wire/NS");
    }
}
