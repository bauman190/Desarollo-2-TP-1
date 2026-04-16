using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    [SerializeField]  private Transform target;
    [SerializeField]  private float baseSpeed = 10f;

    private float radius;
    private float speed = 0f;


    private void Start()
    {
        radius = Vector3.Distance(transform.position, target.position);
        speed = (baseSpeed / radius) * Time.deltaTime;
    }

   
    private void Update()
    {
        transform.RotateAround(target.position, Vector3.up, speed);
    }
}
