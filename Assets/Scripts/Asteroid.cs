using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D astroidRb;
    private AsteroidSpawner spawner;
    private GameManager gameManager;

    [SerializeField] private float astroidSpeed;
    [SerializeField] private int prefabIndex;


    private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
        astroidRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);
    }

    public void SetTrajectory(Vector3 direction)
    {
        astroidRb.AddForce(direction * astroidSpeed);
        Destroy(gameObject, 25.0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(collision.gameObject.tag + prefabIndex);
            spawner.SpawnOnDestroy(gameObject.transform.position, gameObject.transform.rotation, prefabIndex);
            Destroy(gameObject);
            if (prefabIndex >= 2)
            {
                gameManager.IncreaseScore(100);
            }
            else
            {
                gameManager.IncreaseScore(50);
            }

        }




    }

}
