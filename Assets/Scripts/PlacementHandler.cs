using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    public GameObject componentSelectionPrefab;
    public GameObject componentSelectionDisplay;
    public ComponentBase SelectedComponent
    { get => _selectedComponent; }

    private ComponentBase _selectedComponent;

    public void ChangeComponent(ComponentBase to)
    {
        _selectedComponent = to;
    }

    public void DisplayComponentSelections()
    {
        var components = Assembly
            .GetAssembly(typeof(ComponentBase))
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ComponentBase)));

        foreach (var component in components)
        {
            var display = Instantiate(componentSelectionPrefab, componentSelectionDisplay.transform);
            var displaySelector = display.GetComponent<ComponentSelector>();
            displaySelector.Component = (ComponentBase) Activator.CreateInstance(component);
            displaySelector.Number = -1;
        }
    }

    public void Start()
    {
        DisplayComponentSelections();
    }
}
