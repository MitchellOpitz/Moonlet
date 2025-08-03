using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText;
    public TMP_Text gameOverScoreText;
    public TMP_Text gameOverPressText;
    public ScoreManager scoreManager;
    public UIFader fader;
    public SpriteFader spriteFader;
    public AudioSource startSFX;

    public Vector3 playerStartPosition;
    public Vector3 planetStartPosition;
    public GameObject playerPrefab;
    public GameObject planetPrefab;
    public static event Action OnGameStart;

    void OnEnable()
    {
        PlayerBoundsChecker.OnPlayerDeath += HandleGameOver;
    }

    void OnDisable()
    {
        PlayerBoundsChecker.OnPlayerDeath -= HandleGameOver;
    }

    void HandleGameOver()
    {
        StartCoroutine(ShowGameOverSequence());
    }

    IEnumerator ShowGameOverSequence()
    {
        fader.FadeIn(gameOverText);
        fader.FadeIn(gameOverScoreText);
        fader.FadeIn(gameOverPressText);
        gameOverScoreText.text = "Planets visited: " + scoreManager.score.ToString();

        yield return new WaitUntil(() => Input.anyKeyDown);
        if (startSFX != null) startSFX.Play();

        fader.FadeOut(gameOverText);
        fader.FadeOut(gameOverScoreText);
        fader.FadeOut(gameOverPressText);

        yield return new WaitForSeconds(fader.duration);

        GameObject newPlayer = Instantiate(playerPrefab, playerStartPosition, Quaternion.identity);
        GameObject planetHandler = GameObject.Find("PlanetHandler");
        GameObject newPlanet = Instantiate(planetPrefab, planetStartPosition, Quaternion.identity, planetHandler.transform);

        SpriteRenderer playerSprite = newPlayer.GetComponent<SpriteRenderer>();
        SpriteRenderer planetSprite = newPlanet.GetComponent<SpriteRenderer>();

        spriteFader.FadeIn(playerSprite);
        spriteFader.FadeIn(planetSprite);

        OnGameStart?.Invoke();
    }
}
