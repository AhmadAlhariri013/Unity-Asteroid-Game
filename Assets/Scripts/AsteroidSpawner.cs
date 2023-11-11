using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs = new GameObject[6];

    [SerializeField] private float startTime = 2.0f;
    [SerializeField] private float repeatRate = 1.50f;
    [SerializeField] private float spawnDistance = 15.0f;
    [SerializeField] private float rotationRange = 15.0f;


    private void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroids), startTime, repeatRate);
    }

    private void SpawnAsteroids()
    {
        Vector3 spawnDir = Random.insideUnitCircle.normalized * spawnDistance;
        Vector3 spawnPoint = transform.position + spawnDir;

        float varicance = Random.Range(-rotationRange, rotationRange);
        Quaternion rotation = Quaternion.AngleAxis(varicance, Vector3.forward);

        int rndPrefab = Random.Range(0, 6);
        Asteroid asteroid = Instantiate(asteroidPrefabs[rndPrefab], spawnPoint, rotation).GetComponent<Asteroid>();

        asteroid.SetTrajectory(rotation * -spawnDir);
    }


    public void SpawnOnDestroy(Vector3 spawnPoint, Quaternion rotation, int prefabIndex)
    {
        Debug.Log("Prefab Index: " + prefabIndex);
        if (prefabIndex >= 3)
        {
            SplitAsteroid(spawnPoint, rotation);
            SplitAsteroid(spawnPoint, rotation);

        }

    }

    private void SplitAsteroid(Vector3 spawnPoint, Quaternion rotation)
    {
        Vector3 spawnDir = Random.insideUnitCircle.normalized * 0.5f;
        int smallPrefab = Random.Range(0, 3);
        Asteroid asteroid = Instantiate(asteroidPrefabs[smallPrefab], spawnPoint, rotation).GetComponent<Asteroid>();
        asteroid.SetTrajectory(rotation * -spawnDir * 8f);
    }




}
