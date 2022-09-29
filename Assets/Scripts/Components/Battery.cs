using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Battery : ComponentBase
{
    public override string Name { get => "Battery"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/Battery/battery_1"); }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.sprite = Image;
    }
}
