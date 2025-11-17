using UnityEngine;

public class WorldBoundsBuilder : MonoBehaviour
{
    [SerializeField] private float thickness = 1f;
    [SerializeField] private Camera cam;

    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

        BuildBounds();
    }

    private void BuildBounds()
    {
        float height = cam.orthographicSize * 2;
        float width = height * cam.aspect;

        Vector3 camPos = cam.transform.position;

        CreateBound("TopBound", new Vector2(width, thickness), new Vector2(camPos.x, camPos.y + height / 2 + thickness / 2));
        CreateBound("BottomBound", new Vector2(width, thickness), new Vector2(camPos.x, camPos.y - height / 2 - thickness / 2));
        CreateBound("LeftBound", new Vector2(thickness, height), new Vector2(camPos.x - width / 2 - thickness / 2, camPos.y));
        CreateBound("RightBound", new Vector2(thickness, height), new Vector2(camPos.x + width / 2 + thickness / 2, camPos.y));
    }

    private void CreateBound(string name, Vector2 size, Vector2 pos)
    {
        GameObject bound = new GameObject(name);
        bound.transform.parent = this.transform;
        bound.transform.position = pos;

        BoxCollider2D col = bound.AddComponent<BoxCollider2D>();
        col.size = size;
        col.isTrigger = true;
    }
}
