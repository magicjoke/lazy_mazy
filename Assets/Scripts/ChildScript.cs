using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildScript : MonoBehaviour {

    private GameObject player;
    private GameObject respawn;
    //Scene m_Scene;

    public string levelToLoad;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
       //m_Scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
        respawn = GameObject.FindGameObjectWithTag("RespawnPoint");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<ParentScript>().CollisionDetected(this);
        if(collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(respawn.transform.position.x, respawn.transform.position.y, respawn.transform.position.z);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you
        //subscribe to!
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }
}

