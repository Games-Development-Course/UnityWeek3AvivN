using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float interval = 20f;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    private void SpawnPowerUp()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        Instantiate(powerUpPrefab, new Vector3(x, y, 0f), Quaternion.identity);
    }
}
