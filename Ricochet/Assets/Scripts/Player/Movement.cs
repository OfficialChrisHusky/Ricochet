using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float speed = 1.0f;

    [Header("Look")]
    [SerializeField] private float sensitivity = 1.0f;
    [SerializeField] private Transform camera;

    Rigidbody rb;
    Vector2 mouseRot;

    private void Start() {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();

        if (!rb)
            Debug.LogError(gameObject.name + " Doesn't have a Rigidbody attached to it!");

    }
    private void Update() {

        if (!rb) return;

        HandleMovement();
        HandleMouse();

    }

    private void HandleMovement() {

        Vector3 force = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        force.Normalize();

        rb.AddForce(force * speed, ForceMode.Force);

    }
    private void HandleMouse() {

        mouseRot.x += Input.GetAxisRaw("Mouse X") * sensitivity;
        mouseRot.y -= Input.GetAxisRaw("Mouse Y") * sensitivity;

        transform.rotation = Quaternion.Euler(0.0f, mouseRot.x, 0.0f);
        camera.rotation = Quaternion.Euler(mouseRot.y, mouseRot.x, 0.0f);

    }
    
}