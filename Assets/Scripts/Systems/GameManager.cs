using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text titleText;
    public UIFader fader;

    void OnEnable()
    {
        PlayerBoundsChecker.OnPlayerDeath += HandleGameOver;
        TitleScreen.OnGameStart += HandleGameStart;
    }

    void OnDisable()
    {
        PlayerBoundsChecker.OnPlayerDeath -= HandleGameOver;
        TitleScreen.OnGameStart -= HandleGameStart;
    }

    void HandleGameOver()
    {
        fader.FadeOut(scoreText);
        fader.FadeOut(titleText);
        FindObjectOfType<PlanetDespawner>().FadeAndDestroyAll();
        FindObjectOfType<PlanetSpawner>().StopSpawner();
        FindObjectOfType<PlanetScroller>().StopScroller();
    }

    void HandleGameStart()
    {
        FindObjectOfType<PlanetSpawner>().StartSpawner();
        FindObjectOfType<PlanetScroller>().StartScroller();
        fader.FadeIn(scoreText);
        fader.FadeIn(titleText);
    }
}
