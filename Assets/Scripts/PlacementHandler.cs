using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlacementHandler : MonoBehaviour
{
    public GameObject componentSelectionPrefab;
    public GameObject componentSelectionDisplay;
    public Tilemap componentTilemap;
    public ComponentBase SelectedComponent
    { get => _selectedComponent; }

    public delegate void OnComponentChangeDelegate(ComponentBase newComponent);

    public OnComponentChangeDelegate OnComponentChange;

    private ComponentBase _selectedComponent;

    public void ChangeComponent(ComponentBase to)
    {
        _selectedComponent = to;
        OnComponentChange(to);
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
            displaySelector.Component = (ComponentBase) ScriptableObject.CreateInstance(component);
            displaySelector.Number = -1;
        }
    }

    public void Start()
    {
        DisplayComponentSelections();
        ChangeComponent(ScriptableObject.CreateInstance<Dragger>());

        var placementHandler = Global.GetFirstOccurenceOfInRootScene<PlayerInput>();
        var placing = false;
        placementHandler.onActionTriggered += delegate(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case "PlaceStart":
                    if (_selectedComponent.Name == "Dragger") return;
                    placing = context.ReadValue<float>() != 0.0f;
                    break;
                case "PlaceMove":
                    if (placing == false) return;
                    
                    Vector3Int pos = componentTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    pos = new Vector3Int(pos.x, pos.y);
                    if (_selectedComponent.CanPlace(pos) && ((ComponentBase)componentTilemap.GetTile(pos))?.Name != _selectedComponent.Name)
                    {
                        componentTilemap.SetTile(pos, (TileBase) ScriptableObject.CreateInstance(_selectedComponent.GetType()));
                    }
                    
                    break;
            }
        };
    }
}
