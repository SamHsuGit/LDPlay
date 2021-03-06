using UnityEngine;
using UnityEngine.InputSystem;

public class XRMove : MonoBehaviour
{
    public bool touched = false;
    public GameObject playerCamera;
    private float moveForce = 1f;

    public World world;

    private PlayerInputActions touchControls;

    private void Awake()
    {
        touchControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    void Start()
    {
        touchControls.Actions.Touched.started += ctx => StartTouch(ctx);
        touchControls.Actions.Touched.canceled += ctx => EndTouch(ctx);

        world.JoinPlayer(gameObject);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        touched = true;
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        touched = false;
    }

    void Update()
    {
        if (touched)
            transform.Translate(playerCamera.transform.forward * moveForce);
    }
}
