using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    private Vector2 direction;
    private float speed;

    void Start()
    {
        direction = Random.insideUnitCircle.normalized;

        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject);       
        }
    }
}
