using UnityEngine;

public class TripleShot : MonoBehaviour
{
    private bool isActive = false;
    private float duration = 5f;
    private float timer = 0f;

    public bool IsActive()
    {
        return isActive;
    }

    public void ActivateTripleShot()
    {
        isActive = true;
        timer = duration;
    }

    private void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isActive = false;
            }
        }
    }
}
