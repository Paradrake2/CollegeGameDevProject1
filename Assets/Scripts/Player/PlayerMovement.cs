using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpStrength = 4f;
    public float gravity = -20f;
    public float mouseSensitivity = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public LayerMask groundLayer;

    [Header("Camera")]
    public Transform cameraTransform;
    public float maxLookUpAngle = 85f;
    public float minLookDownAngle = -85f;

    private CharacterController controller;
    [SerializeField] private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;
    private float verticalRotation;
    private bool isWalking = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main?.transform;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        LookAround();
        animator.SetBool("isWalking", isWalking);
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        }
        else
        {
            isGrounded = controller.isGrounded;
        }

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 move = Vector3.zero;
        if (cameraTransform != null)
        {
            Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
            move = (forward * moveDirection.z + right * moveDirection.x) * moveSpeed;
        }
        else
        {
            move = transform.TransformDirection(moveDirection) * moveSpeed;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpStrength * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = move + velocity;
        controller.Move(finalMove * Time.deltaTime);

        isWalking = moveDirection.sqrMagnitude > 0f;
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minLookDownAngle, maxLookUpAngle);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        }
    }
}