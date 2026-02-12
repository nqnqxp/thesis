using UnityEngine;
using System.Collections;

public class story : MonoBehaviour
{
    [SerializeField] private Camera c1;
    [SerializeField] private Camera c2;
    [SerializeField] private Camera c2p5;
    [SerializeField] private Camera c3;
    [SerializeField] private Camera c4;
    [SerializeField] private Camera c5;
    [SerializeField] private Camera c6;
    [SerializeField] private Camera fpc;

    public startGame startBool;
    public test handScript;
    public bool eightBall;

    public captionController ccScript;

    public bool resultOut;

    [SerializeField] private GameObject sg;
    //[SerializeField] private GameObject cam5;


    void Start()
    {
        //StartCoroutine(changeCam(6.5f, c2));

        handScript.enabled = false;
        ccScript.enabled = false;

    }

    void Update()
    {
        if (startBool.gameStarted == true)
        {
            StartCoroutine(changeCam(3.5f, c2p5));
            StartCoroutine(scriptControl());
        }


        if (eightBall == true) {
            StartCoroutine(changeCam(0.5f, fpc));
            handScript.camChanged = true;
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

    private IEnumerator changeCam(float seconds, Camera nextCam)
    {
        yield return new WaitForSeconds(seconds);
        //nextCam.depth = 1;
        c1.depth = 0;
        c2.depth = 0;
        c2p5.depth = 0;
        c3.depth = 0;
        c4.depth = 0;
        c5.depth = 0;
        fpc.depth = 0;
        nextCam.depth = 1;

    }

    private IEnumerator scriptControl()
    {
        yield return new WaitForSeconds(6.5f);//change the time accordingly
        handScript.enabled = true;
        ccScript.enabled = true;
    }

    private IEnumerator hsGoodCamTrans()
    {
        c5.GetComponent<Animator>().Play("panC5");
        yield return new WaitForSeconds(6f);
        StartCoroutine(changeCam(2f, c6));
    }
}
