using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthDisplay;

    [SerializeField] private int health = 3;

    private void Start()
    {
        AddHealth();
    }

    private void AddHealth()
    {
        string hearts = "";
        for (int i = 0; i < health; i++)
        {
            hearts += "♥ ";
        }
        HealthDisplay.text = hearts;
    }
}