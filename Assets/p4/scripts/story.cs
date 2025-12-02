using UnityEngine;
using System.Collections;

public class story : MonoBehaviour
{
    [SerializeField] private Camera c1;
    [SerializeField] private Camera c2;
    [SerializeField] private Camera c3;
    [SerializeField] private Camera c4;
    [SerializeField] private Camera c5;
    [SerializeField] private Camera fpc;

    public test fpcBool;
    public bool eightBall;

    public captionController ccScript;

    [SerializeField] private GameObject sg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(changeCam(6.5f, c2));
        StartCoroutine(scriptControl());
    }

    // Update is called once per frame
    void Update()
    {
        if (eightBall == true) {
            StartCoroutine(changeCam(0.1f, fpc));
            fpcBool.camChanged = true;
            sg.GetComponent<Animator>().SetBool("isWalking", false);
            sg.GetComponent<pControl>().enabled = false;
        }
    }

    private IEnumerator changeCam(float seconds, Camera nextCam)
    {
        yield return new WaitForSeconds(seconds);
        c1.depth = 0;
        c2.depth = 0;
        c3.depth = 0;
        c4.depth = 0;
        c5.depth = 0;
        fpc.depth = 0;
        nextCam.depth = 1;

    }

    private IEnumerator scriptControl()
    {
        fpcBool.enabled = false;
        ccScript.enabled = false;
        yield return new WaitForSeconds(6.5f);
        fpcBool.enabled = true;
        ccScript.enabled = true;
    }
}
