using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance;


    public int Death;
    //public int Coin;
    public int MaxLevel;
    public int CurrentLevel;
    //public int checkLevel = 0;
    public int LevelMinusOne;

    public bool RU_ENG = true;

    //public bool onceLevelPlus;

    public int Crystal;
    public float Coins;

    private GameObject player;

    //--SceneNamaThings--//
    Scene currentScene;
    public string currentSceneName;

    //public bool levelOneFinished = false;
    //public bool levelTwoFinished = false;

    private GameObject[] coins;

    // Use this for initialization



    void Awake()
    {
        //coins = new GameObject[coins.length];

        //PlayerPrefs.SetInt("Language", (RU_ENG ? 1 : 0));
        RU_ENG = (PlayerPrefs.GetInt("Language") != 0);

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

    public void EnableRU()
    {
        RU_ENG = true;
        PlayerPrefs.SetInt("Language", (RU_ENG ? 1 : 0));
    }
    public void EnableENG()
    {
        RU_ENG = false;
        PlayerPrefs.SetInt("Language", (RU_ENG ? 0 : 0));
    }



    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        coins = GameObject.FindGameObjectsWithTag("Coin");

        Coins = PlayerPrefs.GetInt("Coin");
        MaxLevel = PlayerPrefs.GetInt("Level");


        if(currentSceneName == "Title_screen")
        {

        }
        else if(currentSceneName == "Language_select")
        {
          
        }
        else if(currentSceneName == "First_level")
        {

        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>();
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }

        //LevelMinusOne = Level - 1;

        //if(Level > LevelMinusOne && levelOneFinished == true)
        //{
        //    for (int i = 0; i < coins.Length; i++)
        //    {
        //        coins[i].GetComponent<CoinController>().isActive = false;
        //    }
        //}




        if(MaxLevel > CurrentLevel)
        {
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].GetComponent<CoinController>().isActive = false;
            }
        }

        //if (currentSceneName == "Level_1" && Level == 0)
        //{
        //    Level++;
        //    PlayerPrefs.SetInt("Level", Level);
        //}

        //if(Level == checkLevel && onceLevelPlus == true)
        //{
        //    onceLevelPlus = false;
        //    checkLevel++;
        //    Level++;
        //    PlayerPrefs.SetInt("Level", Level);
        //}
        if (currentSceneName == "Level_0")
        {
            CurrentLevel = 0;
            if(CurrentLevel == MaxLevel)
            {
                //MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }
        if (currentSceneName == "Level_1")
        {
            CurrentLevel = 1;
            if (CurrentLevel > MaxLevel)
            {
                MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }
        if (currentSceneName == "Level_2")
        {
            CurrentLevel = 2;
            if (CurrentLevel > MaxLevel)
            {
                MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }
        if (currentSceneName == "Level_3")
        {
            CurrentLevel = 3;
            if (CurrentLevel > MaxLevel)
            {
                MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }
        if (currentSceneName == "Level_4")
        {
            CurrentLevel = 4;
            if (CurrentLevel > MaxLevel)
            {
                MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }
        if (currentSceneName == "Level_5")
        {
            CurrentLevel = 5;
            if (CurrentLevel > MaxLevel)
            {
                MaxLevel++;
                PlayerPrefs.SetInt("Level", MaxLevel);
            }
        }


        //if (currentSceneName == "Level_1")
        //{
        //    CurrentLevel = 1;
        //    MaxLevel++;
        //    PlayerPrefs.SetInt("Level", MaxLevel);
        //}
        //if (currentSceneName == "Level_2" && MaxLevel == 1)
        //{
        //    CurrentLevel = 2;
        //    MaxLevel++;
        //    PlayerPrefs.SetInt("Level", MaxLevel);
        //}
        //if (currentSceneName == "Level_3" && MaxLevel == 2)
        //{
        //    CurrentLevel = 3;
        //    MaxLevel++;
        //    PlayerPrefs.SetInt("Level", MaxLevel);
        //}


        //if(Level == 1)
        //{
        //    levelOneFinished = true;
        //}
        //if (Level == 2)
        //{
        //    levelTwoFinished = true;
        //}

        //if (levelOneFinished == true)
        //{
        //    for (int i = 0; i < coins.Length; i++)
        //    {
        //        coins[i].GetComponent<CoinController>().isActive = false;
        //    }
        //}
        //if (levelTwoFinished == true)
        //{
        //    for (int i = 0; i < coins.Length; i++)
        //    {
        //        coins[i].GetComponent<CoinController>().isActive = false;
        //    }
        //}
        //if (currentSceneName == "Level_1" && Level == 0)
        //{
        //    Level++;
        //    PlayerPrefs.SetInt("Level", Level);
        //}
        //if (currentSceneName == "Level_2" && levelTwoFinished == false)
        //{
        //    levelTwoFinished = true;
        //    Level++;
        //    PlayerPrefs.SetInt("Level", Level);
        //}

    }
}
