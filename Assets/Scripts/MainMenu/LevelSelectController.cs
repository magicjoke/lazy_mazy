using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour {

    public GameObject arrow;
    public float arrowSpeed = 2f;
    public float offset = 0.5f;


    public GameObject levelOne;
    public bool one = false;
    public GameObject levelTwo;
    public bool two = false;
    public GameObject levelThree;
    public bool three = false;
    public GameObject levelFour;
    public bool four = false;
    public GameObject levelFive;
    public bool five = false;

    private const float minDistance = 0.03f;

    private void OnMouseDown()
    {

    }


    void Start () {
		
	}
	
    void allOFf()
    {
        one = false;
        two = false;
        three = false;
        four = false;
        five = false;
    }

	void Update () {

        if(one == true)
        {
            arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(levelOne.transform.position.x, levelOne.transform.position.y + offset, levelOne.transform.position.z), Time.deltaTime * arrowSpeed);
            if((arrow.transform.position - new Vector3(levelOne.transform.position.x, levelOne.transform.position.y + offset, levelOne.transform.position.z)).sqrMagnitude <= minDistance * minDistance)
            {
                allOFf();
            }
        }
        if (two == true)
        {
            arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(levelTwo.transform.position.x, levelTwo.transform.position.y + offset, levelTwo.transform.position.z), Time.deltaTime * arrowSpeed);
            if ((arrow.transform.position - new Vector3(levelTwo.transform.position.x, levelTwo.transform.position.y + offset, levelTwo.transform.position.z)).sqrMagnitude <= minDistance * minDistance)
            {
                allOFf();
            }
            Debug.Log("TwoTrue");
        }

        if (three == true)
        {
            arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(levelThree.transform.position.x, levelThree.transform.position.y + offset, levelThree.transform.position.z), Time.deltaTime * arrowSpeed);
            if ((arrow.transform.position - new Vector3(levelThree.transform.position.x, levelThree.transform.position.y + offset, levelThree.transform.position.z)).sqrMagnitude <= minDistance * minDistance)
            {
                allOFf();
            }
        }
        if (four == true)
        {
            arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(levelFour.transform.position.x, levelFour.transform.position.y + offset, levelFour.transform.position.z), Time.deltaTime * arrowSpeed);
            if ((arrow.transform.position - new Vector3(levelFour.transform.position.x, levelFour.transform.position.y + offset, levelFour.transform.position.z)).sqrMagnitude <= minDistance * minDistance)
            {
                allOFf();
            }
        }

        if (five == true)
        {
            arrow.transform.position = Vector3.Lerp(arrow.transform.position, new Vector3(levelFive.transform.position.x, levelFive.transform.position.y + offset, levelFive.transform.position.z), Time.deltaTime * arrowSpeed);
            if ((arrow.transform.position - new Vector3(levelFive.transform.position.x, levelFive.transform.position.y + offset, levelFive.transform.position.z)).sqrMagnitude <= minDistance * minDistance)
            {
                allOFf();
            }
        }       
    }
}
