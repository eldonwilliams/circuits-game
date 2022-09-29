using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Wire : ComponentBase
{
    public override string Name { get => "Wire"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/wire-image"); }
    public RuleTile WireRT
    {
        get => Resources.Load<RuleTile>("WireTile");
    }
}
