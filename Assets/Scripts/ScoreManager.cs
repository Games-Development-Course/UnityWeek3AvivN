using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton זמין בכל מקום

    public int currentScore = 0;

    private void Awake()
    {
        // אם כבר יש אחד – מוחקים את הישן
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  // נשאר חי בין סצנות
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public int GetScore()
    {
        return currentScore;
    }
}
