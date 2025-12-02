using UnityEngine;
using System.Collections;

public class eightballTrigger : MonoBehaviour
{
    public story eightballBool;

    private void OnTriggerEnter(Collider collision)
	{
		StartCoroutine(delayChange());
	}

    private IEnumerator delayChange()
    {
        yield return new WaitForSeconds(1.5f);
        eightballBool.eightBall = true;
    }
}
