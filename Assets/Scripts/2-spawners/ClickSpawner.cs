using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ClickSpawner : MonoBehaviour
{
    [SerializeField]
    protected InputAction spawnAction = new InputAction(type: InputActionType.Button);

    [SerializeField]
    protected GameObject prefabToSpawn;

    [SerializeField]
    protected Vector3 velocityOfSpawnedObject;

    private void OnEnable()
    {
        spawnAction.Enable();
    }

    private void OnDisable()
    {
        spawnAction.Disable();
    }

    protected virtual GameObject SpawnObject()
    {
        Debug.Log("Spawning a new " + prefabToSpawn.name);

        Vector3 positionOfSpawnedObject = transform.position;
        Quaternion rotationOfSpawnedObject = Quaternion.identity;

        GameObject newObject = Instantiate(
            prefabToSpawn,
            positionOfSpawnedObject,
            rotationOfSpawnedObject
        );

        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover != null)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    private void Update()
    {
        if (spawnAction.WasPressedThisFrame())
        {
            SpawnObject();
        }
    }
}
