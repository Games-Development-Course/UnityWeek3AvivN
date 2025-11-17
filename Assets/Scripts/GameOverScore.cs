using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    void Start()
    {
        int finalScore = ScoreManager.instance.currentScore;
        GetComponent<TextMeshProUGUI>().text = finalScore.ToString();
    }
}
