using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals
 * and random bias from its object position.
 */
public class TimedSpawnerRandom : MonoBehaviour
{
    [SerializeField]
    private Mover prefabToSpawn;

    [SerializeField]
    private Vector3 velocityOfSpawnedObject;

    [Tooltip("Minimum time between consecutive spawns, in seconds")]
    [SerializeField]
    private float minTimeBetweenSpawns = 0.2f;

    [Tooltip("Maximum time between consecutive spawns, in seconds")]
    [SerializeField]
    private float maxTimeBetweenSpawns = 1.0f;

    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")]
    [SerializeField]
    private float maxXDistance = 1.5f;

    [SerializeField]
    private Transform parentOfAllInstances;

    private void Start()
    {
        SpawnRoutine();
    }

    private async void SpawnRoutine()
    {
        while (true)
        {
            float timeBetweenSpawnsInSeconds = Random.Range(
                minTimeBetweenSpawns,
                maxTimeBetweenSpawns
            );

            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds);

            if (!this)
            {
                break; // destroyed when changing scenes
            }

            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, maxXDistance),
                transform.position.y,
                transform.position.z
            );

            GameObject newObject = Instantiate(
                prefabToSpawn.gameObject,
                positionOfSpawnedObject,
                Quaternion.identity
            );

            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            newObject.transform.parent = parentOfAllInstances;
        }
    }
}
