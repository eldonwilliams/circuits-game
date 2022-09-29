using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class LightComponent : ComponentBase
{
    public override string Name { get => "Light"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/Light/light1_On"); }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.sprite = Image;
    }
}
