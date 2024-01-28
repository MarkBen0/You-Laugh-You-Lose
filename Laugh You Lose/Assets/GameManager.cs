using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float speed;
    [SerializeField] private TextMeshProUGUI ScoreDisplay;
    [SerializeField] private int score = 0;
    [SerializeField] private float TimeMultuplier = 10;
    [SerializeField] private int ScoreMultuplier = 1;
    [SerializeField] private float ToSpeed;
    [SerializeField] private float TopSpeed;
    [SerializeField] private float SpeedPower;

    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject RestartImage;

    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        StartCoroutine(ScoreCoroutine());
    }
    public void GameEnd()
    {
        Time.timeScale = 0;
        StopCoroutine(ScoreCoroutine());
        RestartButton.active = true;
        RestartImage.active = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        speed = Mathf.Pow(Time.fixedTime/ToSpeed, 1f/SpeedPower)*TopSpeed;
    }

    IEnumerator ScoreCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f / TimeMultuplier);
            score += ScoreMultuplier;
            ScoreDisplay.text = score.ToString();
        }        
    }
}
