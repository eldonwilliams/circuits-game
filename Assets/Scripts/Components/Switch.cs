using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Switch : ComponentBase
{
    public override string Name { get => "Switch"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/Switch/switch1_Off"); }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.sprite = Image;
    }
}
