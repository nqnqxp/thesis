using UnityEngine;

public class shot8Events : MonoBehaviour
{
    public GameObject shot8;
    public GameObject sheep;
    public GameObject spirit;

    public GameObject ant;
    public GameObject hand;
    public GameObject leg;

    public bool localShotStarted;

    void Update()
    {
        if (shot8.gameObject.activeSelf == true && localShotStarted == false)
        {
            sheep.gameObject.SetActive(true);
            spirit.gameObject.SetActive(true);
            ant.gameObject.SetActive(false);
            hand.gameObject.SetActive(false);
            leg.gameObject.SetActive(false);
            localShotStarted = true;
        }
    }
}
