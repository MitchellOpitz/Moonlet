using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    private void OnEnable()
    {
        PlanetScoreTrigger.onPlanetPassed.AddListener(AddPoint);
    }

    private void OnDisable()
    {
        PlanetScoreTrigger.onPlanetPassed.RemoveListener(AddPoint);
    }

    private void AddPoint()
    {
        score++;
        scoreText.text = "Planets visited: " + score.ToString();
    }

    public void ResetScore()
    {
        score = -1;
        AddPoint();
    }
}
