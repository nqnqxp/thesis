using UnityEngine;
using System.Collections;

public class story : MonoBehaviour
{
    [SerializeField] private GameObject c1;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject c2p5;
    [SerializeField] private GameObject c3;
    [SerializeField] private GameObject c4;
    [SerializeField] private GameObject c5;
    [SerializeField] private GameObject c6;
    [SerializeField] private GameObject fpc;

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
            StartCoroutine(changeCam(2.5f, c2p5));
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

    private IEnumerator changeCam(float seconds, GameObject nextCam)
    {
        yield return new WaitForSeconds(seconds);
        //nextCam.depth = 1;
        /*
        c1.GetComponent<Camera>().depth = 0;
        c2.GetComponent<Camera>().depth = 0;
        c2p5.GetComponent<Camera>().depth = 0;
        c3.GetComponent<Camera>().depth = 0;
        c4.GetComponent<Camera>().depth = 0;
        c5.GetComponent<Camera>().depth = 0;
        fpc.GetComponent<Camera>().depth = 0;
        nextCam.GetComponent<Camera>().depth = 1;
        */
        
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c2p5.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        fpc.gameObject.SetActive(false);
        nextCam.gameObject.SetActive(true);

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
