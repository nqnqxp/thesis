using UnityEngine;
using System.Collections;

public class story : MonoBehaviour
{
    [SerializeField] private GameObject shot1;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject shot2;
    [SerializeField] private GameObject c3;
    [SerializeField] private GameObject shot3;
    [SerializeField] private GameObject shot4;
    [SerializeField] private GameObject shot6;
    [SerializeField] private GameObject shot8;
    [SerializeField] private GameObject shot9;
    [SerializeField] private GameObject shot10;
    [SerializeField] private GameObject shot11;
    [SerializeField] private GameObject c4;
    [SerializeField] private GameObject c5;
    [SerializeField] private GameObject c6;
    [SerializeField] private GameObject fpc1;
    [SerializeField] private GameObject fpc2; //shot 5 and 7

    public GameObject sgCharacterSit;
    public GameObject sgCharacterSit3Q;
    public GameObject sgCharacterStand;

    public startGame startBool;
    public test handScript;
    public bool eightBall;

    public captionController ccScript;

    public bool resultOut;

    public bool shot2Started;
    public bool shot3Started;
    public bool shot4Started;
    public bool shot5C;
    public bool shot5Started;
    public bool shot6Started;
    public bool shot7Started;
    public bool shot8Started;
    public bool shot9Started;
    public bool shot10Started;
    public bool shot11Started;
    public bool shot12Started;
    public bool shot13Started;
    public bool shot14Started;
    public bool shot15Started;
    public bool shot16Started;
    public bool shot17Started;

    [SerializeField] private GameObject sg;


    void Start()
    {
        //StartCoroutine(changeCam(6.5f, c2));

        handScript.enabled = false;
        ccScript.enabled = false;
        sg.GetComponent<pControl>().enabled = false; //need to enable it when shot starts somewhere (walking)
        sgCharacterStand.gameObject.SetActive(false);

    }

    void Update()
    {
        if (startBool.gameStarted == true)
        {
            StartCoroutine(changeCam(3.3f, shot2));
            StartCoroutine(detectShotChange(3.3f, shot2Bool));
            startBool.gameStarted = false;
            //StartCoroutine(scriptControl()); //move this to whenever is right before the walking!
        }

        if (shot2Started == true)
        {
            StartCoroutine(changeCam(4f, shot3));
            StartCoroutine(detectShotChange(4f, shot3Bool));
            shot2Started = false;
        }

        if (shot3Started == true)
        {
            StartCoroutine(changeCam(4.75f, shot4));
            StartCoroutine(detectShotChange(4.75f, shot4Bool));
            shot3Started = false;
        }

        if (shot4Started == true)
        {
            StartCoroutine(changeCam(4f, fpc2)); //may tweak after animation is done
            StartCoroutine(detectShotChange(3.96f, shot5Check));//just for shot 5
            StartCoroutine(detectShotChange(4f, shot5Bool));
            shot4Started = false;
        }

        if (shot5Started == true)
        {
            ccScript.enabled = true;
            StartCoroutine(changeCam(3f, shot6));
            StartCoroutine(detectShotChange(3f, shot6Bool));
            shot5Started = false;
        }
        
        if (shot6Started == true && pickLimbs.dragCount == 6)
        {
            StartCoroutine(changeCam(2.5f, fpc2));
            StartCoroutine(detectShotChange(2.5f, shot7Bool));
            StartCoroutine(waitToPlayAnim(4.5f));
            shot6Started = false;
        }
        
        if (shot7Started == true)
        {
            StartCoroutine(changeCam(9.25f, shot8));
            StartCoroutine(detectShotChange(9.25f, shot8Bool)); //what do u think these..
            shot7Started = false;
        }

        if (shot8Started == true)
        {
            StartCoroutine(changeCam(5f, shot9));
            StartCoroutine(detectShotChange(5f, shot9Bool)); //idk
            shot8Started = false;
        }

        if (shot9Started == true)
        {
            //StartCoroutine(waitToPlayIdkAnim());//start of shot9
            StartCoroutine(changeCam(5f, shot10)); //triggers shot 10, number of shots: 10, WS
            StartCoroutine(detectShotChange(5f, shot10Bool));//u believe in fate?
            shot9Started = false;
        }

        // if (shot11.gameObject.activeSelf == true)
        // {
        //     sgCharacterSit3Q.GetComponent<billboard>().enabled = true;
        // }
        // //if (shot11.gameObject.activeSelf == false)
        // else
        // {
        //     sgCharacterSit3Q.transform.eulerAngles = new Vector3(0f, -13.558f, 0f);
        //     sgCharacterSit3Q.GetComponent<billboard>().enabled = false;
        // }

        if (shot10Started == true)
        {
            StartCoroutine(changeCam(5f, shot9)); //number of shots: 11, just going back to shot9 composition
            StartCoroutine(detectShotChange(5f, shot11Bool)); //...
            shot10Started = false;
        }

        if (shot11Started == true)
        {
            //sgCharacterSit3Q.GetComponent<Animator>().Play("nervy");
            StartCoroutine(changeCam(7f, shot8)); //number of shots: 12, just going back to shot8 composition
            StartCoroutine(detectShotChange(7f, shot12Bool)); // 2 lines
            shot11Started = false;
        }

        if (shot12Started == true)
        {
            StartCoroutine(changeCam(5f, shot11)); //number of shots: 13, just going back to shot10 composition
            StartCoroutine(detectShotChange(5f, shot13Bool)); // 2 lines
            shot12Started = false;
        }

        
        if (shot13Started == true)
        {
            StartCoroutine(changeCam(8f, shot9)); //number of shots: 14, just going back to shot9 composition
            StartCoroutine(detectShotChange(8f, shot14Bool)); // i dont want to
            shot13Started = false;
        }

        if (shot14Started == true)
        {
            //StartCoroutine(waitToPlayIdwtAnim());
            StartCoroutine(changeCam(5f, shot8)); //number of shots: 15, just going back to shot8 composition
            StartCoroutine(detectShotChange(5f, shot15Bool)); // so free will... etc.
            shot14Started = false;
        }

        if (shot15Started == true)
        {
            StartCoroutine(changeCam(19f, shot9)); //number of shots: 16, just going back to shot9 composition
            StartCoroutine(detectShotChange(19f, shot16Bool)); // .. I don’t know what my destiny is.
            shot15Started = false;
        }

        if (shot16Started == true)
        {
            //StartCoroutine(waitToPlayIdkmdiAnim());
            StartCoroutine(changeCam(5f, shot8)); //number of shots: 17, just going back to shot8 composition
            StartCoroutine(detectShotChange(5f, shot17Bool)); //Yes you do, etc.
            shot16Started = false;
        }

        //--------------------------------------------------------
        if (eightBall == true) {
            StartCoroutine(changeCam(0.5f, fpc1));
            handScript.camChanged = true; //enable shake input
            sg.GetComponent<Animator>().SetBool("isWalking", false);
            sg.GetComponent<pControl>().enabled = false;
            eightBall = false;
        }

        if (resultOut == false)
        {
            if (handScript.good == true) {
                Debug.Log("changing to grave scene");
                StartCoroutine(changeCam(3f, c5));
                //c5.GetComponent<Animator>().Play("panC5");
                StartCoroutine(hsGoodCamTrans());
                resultOut = true;
            }

            if (handScript.maybe == true && ccScript.firstMaybe == true && ccScript.secondMaybe == true) {
                StartCoroutine(changeCam(1.5f, c4));
                resultOut = true;
            }

            if (handScript.bad == true) {
                StartCoroutine(changeCam(2f, c3));
                resultOut = true;
            }
        }
        
    }

    private IEnumerator waitToPlayIdkAnim()
    {
        yield return new WaitForSeconds(2f);
        sgCharacterSit3Q.GetComponent<Animator>().Play("idk");
    }

    private IEnumerator waitToPlayIdwtAnim()
    {
        yield return new WaitForSeconds(2f);
        sgCharacterSit3Q.GetComponent<Animator>().Play("idwt");
    }

    private IEnumerator waitToPlayIdkmdiAnim()
    {
        yield return new WaitForSeconds(2f);
        sgCharacterSit3Q.GetComponent<Animator>().Play("idkwmdi");
    }

    private IEnumerator waitToPlayAnim(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        fpc2.GetComponent<Animator>().Play("panUp");
    }

    private IEnumerator changeCam(float seconds, GameObject nextCam)
    {
        yield return new WaitForSeconds(seconds);
        shot1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        shot2.gameObject.SetActive(false);
        shot3.gameObject.SetActive(false);
        shot4.gameObject.SetActive(false);
        shot6.gameObject.SetActive(false);
        shot8.gameObject.SetActive(false);
        shot9.gameObject.SetActive(false);
        shot10.gameObject.SetActive(false);
        shot11.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        fpc1.gameObject.SetActive(false);
        fpc2.gameObject.SetActive(false);
        nextCam.gameObject.SetActive(true);

    }

    private IEnumerator detectShotChange(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback.Invoke();
    }

    void shot2Bool()
    {
        shot2Started = true;
    }

    void shot3Bool()
    {
        shot3Started = true;
    }

    void shot4Bool()
    {
        shot4Started = true;
    }

    void shot5Check()
    {
        shot5C = true;
    }

    void shot5Bool()
    {
        shot5Started = true;
    }

    void shot6Bool()
    {
        shot6Started = true;
    }

    void shot7Bool()
    {
        shot7Started = true;
    }

    void shot8Bool()
    {
        shot8Started = true;
    }

    void shot9Bool()
    {
        shot9Started = true;
    }

    void shot10Bool()
    {
        shot10Started = true;
    }
    void shot11Bool()
    {
        shot11Started = true;
    }
    void shot12Bool()
    {
        shot12Started = true;
    }

    void shot13Bool()
    {
        shot13Started = true;
    }

    void shot14Bool()
    {
        shot14Started = true;
    }

    void shot15Bool()
    {
        shot15Started = true;
    }

    void shot16Bool()
    {
        shot16Started = true;
    }

    void shot17Bool()
    {
        shot17Started = true;
    }

    private IEnumerator scriptControl()
    {
        yield return new WaitForSeconds(6.5f);//change the time accordingly
        //already handles enabling movement and disabling movement, check line
        handScript.enabled = true; //doesn't enable 8ball shake entirely, its the same script but theres a bool check above that enables input
        ccScript.enabled = true;
    }

    private IEnumerator hsGoodCamTrans()
    {
        c5.GetComponent<Animator>().Play("panC5");
        yield return new WaitForSeconds(6f);
        StartCoroutine(changeCam(2f, c6));
    }
}
