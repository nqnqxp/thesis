using UnityEngine;

public class shot7Events : MonoBehaviour
{
    //looking down, dialogue start and deer walks up.
    public GameObject shot7; //shot5/7 cam
    public GameObject deer;
    public GameObject rightHand;

    public bool localShotStarted;

    void Update()
    {
        if (shot7.gameObject.activeSelf == true && rightHand.gameObject.activeSelf == true && localShotStarted == false)
        {
            rightHand.gameObject.SetActive(false); //try a fade away transition
            deer.gameObject.SetActive(true);
            localShotStarted = true;
        }
    }
}
