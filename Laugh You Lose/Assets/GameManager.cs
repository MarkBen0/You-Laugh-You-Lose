using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float speed;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }
    
    void Update()
    {

    }
}
