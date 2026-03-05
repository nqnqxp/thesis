using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class new8ballTrigger : MonoBehaviour
{
    //public story eightballBool;
    public TMP_Text fpcCaption;

    private void OnTriggerEnter(Collider collision)
	{
		//StartCoroutine(delayChange());
        fpcCaption.text = "within collider space";
	}

    private void OnTriggerExit(Collider collision)
	{
		//StartCoroutine(delayChange());
        fpcCaption.text = "";
	}

    // private IEnumerator delayChange()
    // {
    //     yield return new WaitForSeconds(1.5f);
    //     eightballBool.eightBall = true;
    // }
}
