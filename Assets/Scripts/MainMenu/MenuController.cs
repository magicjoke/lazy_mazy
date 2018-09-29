using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private float waitTime = 3f;
    public string levelSelect;


    private void OnMouseDown()
    {
        this.GetComponent<Animator>().Play("Button_Start_anim_1");
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelSelect);

    }
}
