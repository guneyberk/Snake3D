using UnityEngine;
using UnityEngine.UI;

public class ScoreTextUpdate : MonoBehaviour
{
    public static int score = 0;
    private Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<Text>();
        score = 0;
    }

    private void Update()
    {
        _scoreText.text = "Score: " + score; 
    }
}
