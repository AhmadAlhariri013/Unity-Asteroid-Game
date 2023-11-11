using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject impactEffect;
    private Rigidbody2D bulletRb;
    private float speed = 10.0f;


    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    private void FixedUpdate()
    {
        bulletRb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
