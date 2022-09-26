using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    public Rect bounds;
    public RangeFloat sizeLimits;
    public float speed;

    private Vector2 _goalPos = new Vector2(0, 0);
    [SerializeField]
    private float goalSize = 5.0f;
    private bool _cameraMoving = false;

    private Camera _camera;

    private PlayerInput _playerInput;

    public void OnPointerMove(InputAction.CallbackContext context)
    {
        if (!_cameraMoving) return;
        
        Vector2 delta = context.ReadValue<Vector2>();
        delta = delta / new Vector2(Screen.width, Screen.width);
        delta = delta * new Vector2(10.0f, 10.0f);
        delta = delta * Mathf.Lerp(0.5f, 1.0f, (goalSize - sizeLimits.min) / (sizeLimits.max - sizeLimits.min));
        _goalPos = _goalPos + delta;
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        goalSize = sizeLimits.Clamp(goalSize + (context.ReadValue<float>() / 10));
    }

    public void OnEvent(InputAction.CallbackContext context)
    {
        switch (context.action.name)
        {
            case "CameraMove_Start":
                _cameraMoving = context.ReadValue<float>() != 0.0f;
                break;
            case "CameraMove":
                OnPointerMove(context);
                break;
            case "CameraScroll":
                OnScroll(context);
                break;
        }
    }
    public void Start()
    {
        foreach (GameObject obj in gameObject.scene.GetRootGameObjects())
            if (obj.GetComponent<Camera>())
                _camera = obj.GetComponent<Camera>();

        _playerInput = GetComponent<PlayerInput>();
        _playerInput.onActionTriggered += OnEvent;
    }

    public void Update()
    {
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, goalSize, speed * Time.deltaTime * 1.75f);

        Vector3 lerpedPosition = Vector3.Lerp(_camera.transform.position, _goalPos, speed * Time.deltaTime);
        _camera.transform.position = new Vector3(lerpedPosition.x, lerpedPosition.y, -10);
    }
}
