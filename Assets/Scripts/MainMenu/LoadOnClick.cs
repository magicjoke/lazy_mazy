using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public string levelToLoad;

    private GameObject levelSelectController;
    private GameObject levelFader;

    private float waitTime = 1f;
    private float smallWaitTime = 2f;

    private void Awake()
    {
        levelSelectController = GameObject.FindGameObjectWithTag("LevelSelectController");
        levelFader = GameObject.FindGameObjectWithTag("LevelFader");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnMouseDown()
    {
        StartCoroutine(LoadLevel());
        //levelSelectController.GetComponent<LevelSelectController>.two = true;
    }

    //if(levelSelectController.GetComponent<LevelSelectController>.)
    IEnumerator LoadLevel()
    {
        levelSelectController.GetComponent<LevelSelectController>().two = true;
        yield return new WaitForSeconds(smallWaitTime);
        levelFader.GetComponent<Animator>().Play("Level_fade_1");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelToLoad);

    }
}
