using UnityEngine;
using System.Collections;

public class story : MonoBehaviour
{
    //get access to all cameras
    [SerializeField] private Camera c1;
    [SerializeField] private Camera c2;
    [SerializeField] private Camera c3;
    [SerializeField] private Camera c4;
    [SerializeField] private Camera c5;
    [SerializeField] private Camera fpc;

    public test fpcBool;
    public bool eightBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(changeCam(5f, c2));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L) && eightBall == true) {
            StartCoroutine(changeCam(0.1f, fpc));
            fpcBool.camChanged = true;
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
}
