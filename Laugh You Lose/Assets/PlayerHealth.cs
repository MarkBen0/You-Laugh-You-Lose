using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthDisplay;

    [SerializeField] private int hearts = 3;

    private void Start()
    {
        AddHealth(0);
    }

    private void AddHealth(int health)
    {
        hearts += health;
        string heartsString = "";
        for (int i = 0; i < hearts; i++)
        {
            heartsString += "♥ ";
        }
        HealthDisplay.text = heartsString;
        if(hearts <= 0)
        {
            GameManager.Instance.GameEnd();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bad"))
        {
            AddHealth(-1);
        }
        if (other.CompareTag("Good"))
        {
            AddHealth(1);
        }
    }
}