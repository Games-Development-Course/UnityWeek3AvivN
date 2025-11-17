using UnityEngine;

public class CleanupScene : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.Find("PlayerSpaceship1");
        if (player != null)
            Destroy(player);
    }
}
