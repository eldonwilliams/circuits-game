using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : ComponentBase
{
    public override string Name { get => "Wire"; }
    public override Sprite Image { get => Resources.Load<Sprite>("Components/wire-image"); }
}
