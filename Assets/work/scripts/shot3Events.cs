using UnityEngine;
using System.Collections;

public class shot3Events : MonoBehaviour
{
    public GameObject hand;
    public GameObject deadAntObj;
    public Animator deadAnt;

    public GameObject shot3;

    public bool localShotStarted;

    void Update()
    {
        if (shot3.gameObject.activeSelf == true && localShotStarted == false)
        {
            StartCoroutine(startScene());
            localShotStarted = true;
        }
    }

    private IEnumerator startScene()
    {
        yield return new WaitForSeconds(2.5f);
        hand.gameObject.SetActive(true);
        deadAnt.SetBool("sceneStarted", true);
        StartCoroutine(disableObjects());
    }

    private IEnumerator disableObjects()
    {
        yield return new WaitForSeconds(2.25f);
        hand.gameObject.SetActive(false);
        deadAntObj.gameObject.SetActive(false);
    }
}
