using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string levelToLoad;
    private GameObject player;
    private GameObject levelExit;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        levelExit = GameObject.FindGameObjectWithTag("Exit");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DontDestroyOnLoad(player);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void CollisionDetected(ChildScript childScript)
    {
        Debug.Log("child collided");
    }
}
