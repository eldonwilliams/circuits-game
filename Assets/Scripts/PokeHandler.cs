using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class PokeHandler : MonoBehaviour
{
    public GameObject groundTilePrefab;

    private Tilemap _tilemap;
    private PlayerInput _playerInput;

    public void OnEvent(InputAction.CallbackContext context)
    {
        if (context.action.name != "Poke") return;
        if (context.phase != InputActionPhase.Started) return;

        Vector3Int pos = _tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        pos = new Vector3Int(pos.x, pos.y);
        if (!_tilemap.HasTile(pos)) {
            var newTile = ScriptableObject.CreateInstance<Tile>();
            newTile.gameObject = groundTilePrefab;
            _tilemap.SetTile(pos, newTile);
        }

        GameObject goTile = _tilemap.GetInstantiatedObject(pos);
        goTile.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        goTile.transform.LeanScale(new Vector3(1,1,1), 0.35f).setEaseOutBack().setOnComplete(() => {
            goTile.transform.localScale = new Vector3(1f, 1f, 1f);
        });

        goTile.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        LeanTween.alpha(goTile, 1, 0.35f).setEaseOutBack();
        
        goTile.transform.position -= new Vector3(0, 0.75f);
        goTile.transform.LeanMove(_tilemap.CellToWorld(pos), 0.35f).setEaseOutBack().setOnComplete(() => {
            goTile.transform.position = _tilemap.CellToWorld(pos);
        });
    }

    public void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.onActionTriggered += OnEvent;
    }
}
