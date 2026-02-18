using UnityEngine;

public class shot6Events : MonoBehaviour
{
    public GameObject ants;

    public GameObject shot6;
    public GameObject rightHand;

    public bool localShotStarted;

    // Update is called once per frame
    void Update()
    {
        if (shot6.gameObject.activeSelf == true && localShotStarted == false)
        {
            ants.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(true);
            localShotStarted = true;
        }
    }
}
