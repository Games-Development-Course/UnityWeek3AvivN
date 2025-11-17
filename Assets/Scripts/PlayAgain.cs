using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public string levelName = "level-1";

    public void Restart()
    {
        SceneManager.LoadScene(levelName);
    }
}
