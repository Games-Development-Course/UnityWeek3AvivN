using UnityEngine;

public class WorldBoundsBuilder : MonoBehaviour
{
    [SerializeField] private float thickness = 1f;
    [SerializeField] private Camera cam;

    private Transform boundsParent;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        boundsParent = new GameObject("DynamicBounds").transform;
        boundsParent.parent = transform;

        BuildBounds();
    }

    private void Update()
    {
        BuildBounds();
    }

    private void BuildBounds()
    {
        foreach (Transform child in boundsParent)
        {
            Destroy(child.gameObject);
        }

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;
        Vector3 camPos = cam.transform.position;

        CreateBound(
            "TopBound",
            new Vector2(width, thickness),
            new Vector2(camPos.x, camPos.y + height / 2f + thickness / 2f),
            false
        );

        CreateBound(
            "BottomBound",
            new Vector2(width, thickness),
            new Vector2(camPos.x, camPos.y - height / 2f - thickness / 2f),
            false
        );

        CreateBound(
            "LeftBound",
            new Vector2(thickness, height),
            new Vector2(camPos.x - width / 2f - thickness / 2f, camPos.y),
            true
        );

        CreateBound(
            "RightBound",
            new Vector2(thickness, height),
            new Vector2(camPos.x + width / 2f + thickness / 2f, camPos.y),
            true
        );
    }

    private void CreateBound(string name, Vector2 size, Vector2 pos, bool isTrigger)
    {
        GameObject bound = new GameObject(name);
        bound.transform.parent = boundsParent;
        bound.transform.position = pos;

        BoxCollider2D col = bound.AddComponent<BoxCollider2D>();
        col.size = size;
        col.isTrigger = isTrigger;
    }
}
