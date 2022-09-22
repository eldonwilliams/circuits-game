using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PokeHandler : MonoBehaviour
{
    public Tile groundTile;

    private Tilemap tilemap;
    private PlayerInput playerInput;

    public void OnEvent(InputAction.CallbackContext context)
    {
        if (context.action.name != "Poke") return;
        if (context.phase != InputActionPhase.Started) return;

        Vector3Int pos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        pos = new Vector3Int(pos.x, pos.y);
        if (!tilemap.HasTile(pos))
            tilemap.SetTile(pos, groundTile);
    }

    public void Start()
    {
        tilemap = GetComponent<Tilemap>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += OnEvent;
    }
}
