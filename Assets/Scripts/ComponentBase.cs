using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * Describes the basic parts of a Component
 * Can be extended using a sub-class
 */
public class ComponentBase
{
    public virtual string Name { get => "COMP_BASE"; }
    /** The Sprite to use when previewing this Component */
    public virtual Sprite Image { get => Resources.Load<Sprite>("Components/cube"); }
    
    public virtual bool CanPlace(Vector3Int at)
    {
        var renderers = Global.GetFirstOccurenceOfInScene<Grid>().GetComponentsInChildren<TilemapRenderer>().Where(renderer => renderer.sortingOrder == 1);
        Tilemap tilemap = default;
        foreach (var renderer in renderers)
        {
            tilemap = renderer.GetComponent<Tilemap>();
        }

        return tilemap ? tilemap.HasTile(at) : false;
    }
}
