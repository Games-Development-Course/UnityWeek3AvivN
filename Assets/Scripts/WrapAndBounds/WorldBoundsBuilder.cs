using UnityEngine;

public class WorldBoundsBuilder : MonoBehaviour
{
    [SerializeField] private float thickness = 1f;
    [SerializeField] private Camera cam;

    private Transform boundsParent;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        // Parent for easy cleanup
        boundsParent = new GameObject("DynamicBounds").transform;
        boundsParent.parent = this.transform;

        BuildBounds();
    }

    void Update()
    {
        BuildBounds(); // Rebuild every frame (safe + cheap)
    }

    private void BuildBounds()
    {
        // Delete old bounds
        foreach (Transform child in boundsParent)
            Destroy(child.gameObject);

        float height = cam.orthographicSize * 2;
        float width = height * cam.aspect;
        Vector3 camPos = cam.transform.position;

        // Top bound (block)
        CreateBound("TopBound",
            new Vector2(width, thickness),
            new Vector2(camPos.x, camPos.y + height / 2 + thickness / 2),
            false);

        // Bottom bound (block)
        CreateBound("BottomBound",
            new Vector2(width, thickness),
            new Vector2(camPos.x, camPos.y - height / 2 - thickness / 2),
            false);

        // Left bound (wrap)
        CreateBound("LeftBound",
            new Vector2(thickness, height),
            new Vector2(camPos.x - width / 2 - thickness / 2, camPos.y),
            true);

        // Right bound (wrap)
        CreateBound("RightBound",
            new Vector2(thickness, height),
            new Vector2(camPos.x + width / 2 + thickness / 2, camPos.y),
            true);
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
