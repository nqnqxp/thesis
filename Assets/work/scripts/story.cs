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
    [SerializeField] private GameObject c4;
    [SerializeField] private GameObject c5;
    [SerializeField] private GameObject c6;
    [SerializeField] private GameObject fpc1;
    [SerializeField] private GameObject fpc2;

    public GameObject sgCharacterSit;
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

    [SerializeField] private GameObject sg;


    void Start()
    {
        //StartCoroutine(changeCam(6.5f, c2));

        handScript.enabled = false;
        ccScript.enabled = false;
        sg.GetComponent<pControl>().enabled = false; //need to enable it when shot starts somewhere
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
            StartCoroutine(detectShotChange(3.96f, shot5Check));//just for shot 5, add one more line for next shot
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

        //next shot
        // if (shot6Started == true)
        // {
        //     StartCoroutine(changeCam(3f, shot6));
        //     shot6Started = false;
        // }
        


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

    private IEnumerator changeCam(float seconds, GameObject nextCam)
    {
        yield return new WaitForSeconds(seconds);
        shot1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        shot2.gameObject.SetActive(false);
        shot3.gameObject.SetActive(false);
        shot4.gameObject.SetActive(false);
        shot6.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        fpc1.gameObject.SetActive(false);
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
