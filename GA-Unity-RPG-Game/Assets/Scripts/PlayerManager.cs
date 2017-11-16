using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    
    }

    #endregion

    public GameObject player;

    public void KillPlayer ()
    {
        //Gameover screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}