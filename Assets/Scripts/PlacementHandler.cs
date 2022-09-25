using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    public ComponentBase SelectedComponent
    { get => _selectedComponent; }

    private ComponentBase _selectedComponent;

    public void ChangeComponent(ComponentBase to)
    {
        _selectedComponent = to;
    }
}
