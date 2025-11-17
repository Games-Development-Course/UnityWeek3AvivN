using UnityEngine;

public class HorizontalWrap : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private float leftLimit;
    private float rightLimit;

    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;
    }

    private void Update()
    {
        UpdateLimits();  

        Vector3 pos = transform.position;

        if (pos.x < leftLimit)
            pos.x = rightLimit;

        else if (pos.x > rightLimit)
            pos.x = leftLimit;

        transform.position = pos;
    }

    private void UpdateLimits()
    {
        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;
        float halfW = width / 2f;

        Vector3 c = cam.transform.position;

        leftLimit = c.x - halfW;
        rightLimit = c.x + halfW;
    }
}
