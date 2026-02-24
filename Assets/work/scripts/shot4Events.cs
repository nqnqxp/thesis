using UnityEngine;
using System.Collections;

public class shot4Events : MonoBehaviour
{
    public GameObject shot4;
    public Animator sitting;
    public bool localShotStarted;

    void Update()
    {
        if (shot4.gameObject.activeSelf == true && localShotStarted == false)
        {
            StartCoroutine(moveHand());
            localShotStarted = true;
        }
    }

    private IEnumerator moveHand()
    {
        yield return new WaitForSeconds(1f);
        sitting.SetBool("moveHand", true);
    }
}
