using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject Image;

    void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        StartCoroutine(ScoreCoroutine());
        StartButton.active = false;
        Image.active = false;
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
