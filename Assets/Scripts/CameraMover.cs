using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{
    public Rect bounds;
    public RangeFloat sizeLimits;
    public float speed;

    private Vector2 goalPos = new Vector2(0, 0);
    [SerializeField]
    private float goalSize = 5.0f;
    private bool cameraMoving = false;

    private new Camera camera;

    private PlayerInput playerInput;

    public void OnPointerMove(InputAction.CallbackContext context)
    {
        if (!cameraMoving) return;
        
        Vector2 delta = context.ReadValue<Vector2>();
        delta = delta / new Vector2(Screen.width, Screen.width);
        delta = delta * new Vector2(10.0f, 10.0f);
        delta = delta * Mathf.Lerp(0.5f, 1.0f, (goalSize - sizeLimits.min) / (sizeLimits.max - sizeLimits.min));
        goalPos = goalPos + delta;
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
                cameraMoving = context.ReadValue<float>() != 0.0f;
                break;
            case "CameraMove":
                OnPointerMove(context);
                break;
            case "CameraScroll":
                OnScroll(context);
                break;
            default:
                break;
        }
    }
    public void Start()
    {
        foreach (GameObject obj in gameObject.scene.GetRootGameObjects())
            if (obj.GetComponent<Camera>())
                camera = obj.GetComponent<Camera>();

        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnEvent;
    }

    public void Update()
    {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, goalSize, speed * Time.deltaTime * 1.75f);

        Vector3 lerpedPosition = Vector3.Lerp(camera.transform.position, goalPos, speed * Time.deltaTime);
        camera.transform.position = new Vector3(lerpedPosition.x, lerpedPosition.y, -10);
    }
}
