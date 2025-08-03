using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public AudioSource scoreSFX;
    private bool firstTime = true;

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
        if (!firstTime && scoreSFX != null) scoreSFX.Play();
        firstTime = false;
    }

    public void ResetScore()
    {
        score = -1;
        firstTime = true;
        AddPoint();
    }
}
