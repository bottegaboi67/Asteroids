using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ship parameters")]
    [SerializeField] private float shipAcceleration = 10f;
    [SerializeField] private float shipMaxVelocity = 10f;
    [SerializeField] private float shipRotationSpeed = 200f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float shootCooldown = 0.2f;

    private float shootTimer;

    private Rigidbody2D shipRigidbody;
    private bool isAlive = true;
    private bool isAccelerating = false;

    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAlive)
        {
            HandleShipAcceleration();
            HandleShipRotation();
            HandleShooting(); 
            
        }
    }

    private void FixedUpdate()
    {
        if (isAlive && isAccelerating)
        {
            shipRigidbody.AddForce(transform.up * shipAcceleration);
            shipRigidbody.velocity = Vector2.ClampMagnitude(shipRigidbody.velocity, shipMaxVelocity);
        }
    }

    private void HandleShipAcceleration()
    {
        isAccelerating = Input.GetKey(KeyCode.UpArrow);
    }

    private void HandleShipRotation()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)){
            rotation = shipRotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            rotation = -shipRotationSpeed * Time.deltaTime;
        }
        transform.Rotate(0f, 0f, rotation);
    }

    private void HandleShooting()
    {
        shootTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && shootTimer <= 0f)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shootTimer = shootCooldown;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Asteroid"))
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}

}
