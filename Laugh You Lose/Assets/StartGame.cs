using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //[SerializeField] Game;
    // Start is called before the first frame update
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
}
