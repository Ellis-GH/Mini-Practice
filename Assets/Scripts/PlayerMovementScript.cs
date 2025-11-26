using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRotationScript spriteRotator;

    private InputSystem_Actions controls;
    private Vector2 moveInput;

    [SerializeField] float movementSpeed = 5f;
    

    private void Awake()
    {
        controls = new InputSystem_Actions();

        //Not sure what these 2 lines do exactly
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        rb = GetComponent<Rigidbody2D>();
        spriteRotator = GetComponent<SpriteRotationScript>();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * movementSpeed * Time.deltaTime);
        if(moveInput.magnitude != 0) { spriteRotator.SetOrientation(moveInput); }

        //Debug.Log("Move input is: " + moveInput);
        //Time.deltaTime is a small number, like 0.01, but is tied to framerate, or the change in time between now and the last frame.
        //If not multiplied in, the player will move at [movementSpeed] every frame, which means they move slower at a slow framerate.
    }


}
