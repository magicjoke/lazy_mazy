using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;


    public int Death;
    //public int Coin;
    public int Level;
    public int LevelMinusOne;
    public int Crystal;
    public float Coins;

    private GameObject player;

    //--SceneNamaThings--//
    Scene currentScene;
    public string currentSceneName;

    public bool levelOneFinished = false;
    public bool levelTwoFinished = false;

    private GameObject[] coins;

    // Use this for initialization



    void Awake()
    {
        //coins = new GameObject[coins.length];

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        coins = GameObject.FindGameObjectsWithTag("Coin");

        Coins = PlayerPrefs.GetInt("Coin");
        Level = PlayerPrefs.GetInt("Level");

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>();

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }

        LevelMinusOne = Level - 1;

        if(Level > LevelMinusOne && levelOneFinished == true)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].GetComponent<CoinController>().isActive = false;
            }
        }

        if(Level == 1)
        {
            levelOneFinished = true;
        }
        //if (Level == 2)
        //{
        //    levelTwoFinished = true;
        //}

        if (levelOneFinished == true)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].GetComponent<CoinController>().isActive = false;
            }
        }
        //if (levelTwoFinished == true)
        //{
        //    for (int i = 0; i < coins.Length; i++)
        //    {
        //        coins[i].GetComponent<CoinController>().isActive = false;
        //    }
        //}
        if (currentSceneName == "Level_1" && levelOneFinished == false)
        {
            levelOneFinished = true;
            Level++;
            PlayerPrefs.SetInt("Level", Level);
        }
        //if (currentSceneName == "Level_2" && levelTwoFinished == false)
        //{
        //    levelTwoFinished = true;
        //    Level++;
        //    PlayerPrefs.SetInt("Level", Level);
        //}

    }
}
