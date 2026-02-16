using UnityEngine;
using System.Collections;

public class shot3Events : MonoBehaviour
{
    public GameObject hand;
    public GameObject deadAntObj;
    public Animator deadAnt;

    public GameObject shot3;

    void Update()
    {
        if (shot3.gameObject.activeSelf == true)
        {
            hand.gameObject.SetActive(true);
            deadAnt.SetBool("sceneStarted", true);
            StartCoroutine(disableObjects());

        }
    }

    private IEnumerator disableObjects()
    {
        yield return new WaitForSeconds(2.25f);
        hand.gameObject.SetActive(false);
        deadAntObj.gameObject.SetActive(false);
    }
}
