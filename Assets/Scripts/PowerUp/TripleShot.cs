using UnityEngine;

public class TripleShot : MonoBehaviour
{
    public LaserShooter shooter;
    public float duration = 5f;

    private bool active = false;
    private float timer = 0f;

    void Update()
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                active = false;
            }
        }
    }

    public void ActivateTripleShot()
    {
        active = true;
        timer = duration;
    }

    public bool IsActive()
    {
        return active;
    }
}
