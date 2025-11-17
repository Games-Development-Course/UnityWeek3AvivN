using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton ���� ��� ����

    public int currentScore = 0;

    private void Awake()
    {
        // �� ��� �� ��� � ������ �� ����
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ���� �� ��� �����
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
