using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    private Rigidbody rb;
    private Vector3 movment;
    private Vector3 rotation;
    [SerializeField]private float rotationSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float movmentY = 0;

        if (Input.GetKey(KeyCode.Space))
            movmentY = 1;
        if (Input.GetKey(KeyCode.LeftControl))
            movmentY = -1;

        float rotationInput = 0;
        if (Input.GetKey(KeyCode.Q))
            rotationInput = -1;
        if (Input.GetKey(KeyCode.E))
            rotationInput = 1;

        //movment = new Vector3(Input.GetAxisRaw("Horizontal"), movmentY, Input.GetAxisRaw("Vertical"));
        movment = transform.forward * Input.GetAxisRaw("Vertical")
        + transform.right * Input.GetAxisRaw("Horizontal")
        + Vector3.up * movmentY;
        rotation = new Vector3(0, rotationInput, 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movment * speed);
        rb.AddTorque(rotation * rotationSpeed, ForceMode.Force);
    }
}

