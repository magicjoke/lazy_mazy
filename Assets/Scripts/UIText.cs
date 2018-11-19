using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIText : MonoBehaviour
{
    private Text Title;
    private Text Description;
    private Text Button;

    public string TitleRU;
    public string TitleENG;
    public string DescriptionRU;
    public string DescriptionENG;
    public string ButtonRU;
    public string ButtonENG;

    private GameObject levelManger;
    private GameObject levelFader;

    public string nextLevel;


    // Start is called before the first frame update
    void Start()
    {
        Title = GameObject.FindGameObjectWithTag("Title").GetComponent<Text>();
        Description = GameObject.FindGameObjectWithTag("Description").GetComponent<Text>();
        Button = GameObject.FindGameObjectWithTag("Button").GetComponent<Text>();
        levelManger = GameObject.FindGameObjectWithTag("LevelManager");
        levelFader = GameObject.FindGameObjectWithTag("LevelFader");
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManger.GetComponent<LevelManager>().RU_ENG == true)
        {
            //text.text = signText;
            Title.text = TitleRU;
            Description.text = DescriptionRU;
            Button.text = ButtonRU;
        }
        else
        {
            Title.text = TitleENG;
            Description.text = DescriptionENG;
            Button.text = ButtonENG;
        }
    }

    public void NextLevel()
    {
        StartCoroutine(ChangeLevel());
    }


    IEnumerator ChangeLevel()
    {
        levelFader.GetComponent<Animator>().Play("Level_fade_1");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevel);
    }
}
