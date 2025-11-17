using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component spawns the given object at fixed time-intervals at its object position.
 */
public class TimedSpawner : MonoBehaviour
{
    [SerializeField]
    private Mover prefabToSpawn;

    [SerializeField]
    private Vector3 velocityOfSpawnedObject;

    [SerializeField]
    private float secondsBetweenSpawns = 1f;

    private void Start()
    {
        SpawnRoutine();
        Debug.Log("Start finished");
    }

    private async void SpawnRoutine()
    {
        while (true)
        {
            GameObject newObject = Instantiate(
                prefabToSpawn.gameObject,
                transform.position,
                Quaternion.identity
            );
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);

            await Awaitable.WaitForSecondsAsync(secondsBetweenSpawns);
        }
    }
}
