using UnityEngine;

public class shot5Events : MonoBehaviour
{
    public GameObject sgCharacterSit;
    public GameObject shot5;

    public GameObject newDeadAnt;
    public GameObject hand;
    public GameObject legs;

    public story shot5Bool;

    public bool localShotStarted;

    void Update()
    {
        if (shot5Bool.shot5C == true && localShotStarted == false)
        {
            sgCharacterSit.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            newDeadAnt.gameObject.SetActive(true);
            hand.gameObject.SetActive(true);
            legs.gameObject.SetActive(true);
            localShotStarted = true;
        }
    }
}
