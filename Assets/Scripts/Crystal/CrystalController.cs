using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrystalController : MonoBehaviour
{

    public bool onPlace = false;
    public bool createdOnce = false;
    private bool sms = false;

    public bool closeDoor = false;
    public float waitTime = 2f;
    public float blueColliderWaitTime = 1f;

    private GameObject blueDoor;
    private GameObject blueDoorLight;

    public bool activeRedDoor;

    private GameObject redDoor;
    private GameObject redDoorLight;
    private GameObject redLight;

    public GameObject crystal;

    private string sceneName;

    void Awake()
    {

        blueDoor = GameObject.FindGameObjectWithTag("Blue_door");
        blueDoorLight = GameObject.FindGameObjectWithTag("Blue_door_light");

        redDoor = GameObject.FindGameObjectWithTag("Red_door");
        redDoorLight = GameObject.FindGameObjectWithTag("Red_door_light");
    }

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

    void Update()
    {

        if (onPlace == true && sms == false)
        {
            Debug.Log("OnPlace=True");
            sms = true;
            blueDoor.GetComponent<Animator>().Play("Blue_door_opening_1");
            StartCoroutine(DissableBlueCollider());
            blueDoorLight.GetComponent<Animator>().Play("Blue_door_light_idle_1");
        }
        if (closeDoor == true)
        {
            closeDoor = false;
            blueDoor.GetComponent<Animator>().Play("Blue_door_closing_1");
            blueDoor.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(BlueLightPause());
        }
        if (activeRedDoor == true)
        {
            activeRedDoor = false;
            redDoor.GetComponent<Animator>().Play("Red_door_closing_1");
            redDoor.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(RedLightPause());
        }
        if (sceneName == "Title_screen")
        {
            redDoor.GetComponent<Animator>().Play("Red_door_1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && createdOnce == false)
        {
            GetComponent<Animator>().Play("Crystal_empty_1");
            Instantiate(crystal, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            createdOnce = true;
        }

    }

    IEnumerator BlueLightPause()
    {
        yield return new WaitForSeconds(waitTime);
        blueDoorLight.GetComponent<Animator>().Play("Blue_door_light_1");
    }

    IEnumerator RedLightPause()
    {
        yield return new WaitForSeconds(waitTime);
        redDoorLight.GetComponent<Animator>().Play("Red_door_light_1");
    }

    IEnumerator DissableBlueCollider()
    {
        yield return new WaitForSeconds(blueColliderWaitTime);
        blueDoor.GetComponent<BoxCollider2D>().enabled = false;

    }
}
