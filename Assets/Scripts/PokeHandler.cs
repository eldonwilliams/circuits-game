using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PokeHandler : MonoBehaviour
{
    public GameObject groundTilePrefab;

    private Tilemap tilemap;
    private PlayerInput playerInput;

    public void OnEvent(InputAction.CallbackContext context)
    {
        if (context.action.name != "Poke") return;
        if (context.phase != InputActionPhase.Started) return;

        Vector3Int pos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        pos = new Vector3Int(pos.x, pos.y);
        if (!tilemap.HasTile(pos)) {
            Tile newTile = ScriptableObject.CreateInstance<Tile>();
            newTile.gameObject = groundTilePrefab;
            tilemap.SetTile(pos, newTile);
        }

        GameObject go_tile = tilemap.GetInstantiatedObject(pos);
        go_tile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        go_tile.transform.LeanScale(new Vector3(1,1,1), 0.35f).setEaseOutBack().setOnComplete(() => {
            go_tile.transform.localScale = new Vector3(1f, 1f, 1f);
        });

        go_tile.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.0f);
        LeanTween.alpha(go_tile, 1, 0.35f).setEaseOutBack();

        Vector3 normalPosition = go_tile.transform.position;
        go_tile.transform.position -= new Vector3(0, 0.75f);
        go_tile.transform.LeanMove(tilemap.CellToWorld(pos), 0.35f).setEaseOutBack().setOnComplete(() => {
            go_tile.transform.position = tilemap.CellToWorld(pos);
        });
    }

    public void Start()
    {
        tilemap = GetComponent<Tilemap>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += OnEvent;
    }
}
