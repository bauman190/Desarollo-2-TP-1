using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControler : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movment;
    private Vector3 rotation;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float rotationSpeedKinetic = 20f;

    [SerializeField] private float shipInpuls = 1f;

    //Bullet 
    [SerializeField] private Bullet prefabBullet;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private Transform tip;
    [SerializeField] private Transform bulletContent;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ToggleKinematic();
        Movement();
        Shoot();
    }
    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
           Bullet bullet = Instantiate(prefabBullet, tip.position, tip.rotation, bulletContent); 
           bullet.Logic(bulletSpeed);
        }
        
    }
    private void Movement()
    {        

        if (Input.GetKey(KeyCode.Space))
        {
            movment = transform.forward * shipInpuls;
        }

        float rotationInput = 0;
        if (Input.GetKey(KeyCode.Q))
            rotationInput = -1;
        if (Input.GetKey(KeyCode.E))
            rotationInput = 1;

        rotation = new Vector3(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), rotationInput);

        if (rb.isKinematic)
        {
            transform.Rotate(rotation * rotationSpeedKinetic * Time.deltaTime);
            transform.position += movment* Time.deltaTime;
        }
    }
  
    private void FixedUpdate()
    {
        rb.AddForce(movment);
        rb.AddTorque(rotation * rotationSpeed, ForceMode.Force);
    }

    private void ToggleKinematic()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
           rb.isKinematic = !rb.isKinematic;
    }
}

