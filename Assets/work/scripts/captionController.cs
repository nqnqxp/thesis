using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class captionController : MonoBehaviour
{
    public float idleThreshold = 6f;

    private float idleTimer = 0f;
    private Vector3 lastMousePos;

    public TMP_Text fpcCaption;
    public TMP_Text c2Caption;
    public TMP_Text c3Caption;
    public TMP_Text c4Caption;
    public TMP_Text c5Caption;

    public TMP_Text shot6Caption;

    public List<string> idleTexts;

    public test handScript;

    //public pickLimbs checkDragCount;
    public bool resetOdd;
    public bool resetEven;

    public bool fpcTextDone;
    private bool n1Done;

    public bool firstMaybe;
    public bool secondMaybe;

    //public GameObject shotW;
    public GameObject shot6;
    public bool reset;
    public bool reset2;
    public bool reset3;
    public bool reset4;
    public bool reset5;
    public bool reset6;


    void Update()
    {
        //loves me, loves me not
        if (shot6.gameObject.activeSelf == true)
        {
            if (pickLimbs.dragCount > 0)
            {
                if (pickLimbs.lovesMe == true && resetOdd == false)
                {
                    resetEven = false;
                    string shot6Text1 = "she loves me...";
                    StartCoroutine(fpc1ChangeText(shot6Caption, 2f, shot6Text1));
                    resetOdd = true;
                }
                if (pickLimbs.lovesMe == false && resetEven == false)
                {
                    resetOdd = false;
                    string shot6Text2 = "she loves me not...";
                    StartCoroutine(fpc1ChangeText(shot6Caption, 2f, shot6Text2));
                    resetEven = true;
                }
            }


        }
        /*
        if (shotW.gameObject.activeSelf == true) //needs tweaking, also change W to accurate shot number when comes up
        {
            // D timer for c2
            if (Input.GetKey(KeyCode.D))
            {
                idleTimer = 0f;
            }
            else
            {
                idleTimer += Time.deltaTime/8;
            }

            if (idleTimer >= idleThreshold)
            {
                StartCoroutine(IdleText(c2Caption, 3f));
                idleTimer = 0f;
            }
        }
        */

        //FPC/Mouse Stuff

        if (handScript.camChanged == true)
        {
            if (n1Done == false)
            {
                string n1 = "am I ready to visit ******?";
                StartCoroutine(fpcChangeText(fpcCaption, 1.5f, 2f, n1));
                n1Done = true;
            }

            if(fpcTextDone == true)
            {
                MouseTimer();
            }

        }

        //8ball no result

        if (handScript.maybe == true && firstMaybe == false && secondMaybe == false) {
            string n2 = "huh...?";
            StartCoroutine(customChangeText1(fpcCaption, 2.5f, 2f, n2));
            firstMaybe = true;
            //StartCoroutine(delayMcheck());
        }
        
    }

    private void MouseTimer()
    {
        lastMousePos = Input.mousePosition;

        Vector3 currentMousePos = Input.mousePosition;

        if (currentMousePos != lastMousePos)
        {
            idleTimer = 0f;
            lastMousePos = currentMousePos;
        }
        else
        {
            idleTimer += Time.deltaTime/8;
        }

        if (idleTimer >= idleThreshold)
        {
            StartCoroutine(IdleText(fpcCaption, 3f));
            idleTimer = 0f;
        }
    }

    private IEnumerator IdleText(TMP_Text caption, float seconds)
    {
        int randomIndex = Random.Range(0, idleTexts.Count);
        caption.fontStyle = FontStyles.Italic;
        caption.text = idleTexts[randomIndex];
        yield return new WaitForSeconds(seconds);
        caption.fontStyle = FontStyles.Normal;
        caption.text = " ";
    }

    private IEnumerator changeText(TMP_Text caption, float wait, float stay, string text)
    {
        fpcTextDone = false;
        yield return new WaitForSeconds(wait);
        caption.text = text;
        yield return new WaitForSeconds(stay);
        caption.text = " ";
        fpcTextDone = true;
    }

    private IEnumerator customChangeText1(TMP_Text caption, float wait, float stay, string text)
    {
        fpcTextDone = false;
        yield return new WaitForSeconds(wait);
        caption.text = text;
        yield return new WaitForSeconds(stay);
        caption.text = " ";
        fpcTextDone = true;
        handScript.shaken = false;
        handScript.changed = false;

        StartCoroutine(loopCheck());
    }

    private IEnumerator loopCheck()
    {
        yield return new WaitForSeconds(0.5f);
        if (handScript.changed == true && handScript.maybe == true && firstMaybe == true) {
            string n3 = "...";
            StartCoroutine(customChangeText(fpcCaption, 2.5f, 2f, n3));
        }
        else if(handScript.maybe == true)
        {
            StartCoroutine(loopCheck());
        }
    }

    private IEnumerator customChangeText(TMP_Text caption, float wait, float stay, string text)
    {
        fpcTextDone = false;
        yield return new WaitForSeconds(wait);
        caption.text = text;
        yield return new WaitForSeconds(stay);
        caption.text = " ";
        fpcTextDone = true;
        handScript.shaken = false;
        handScript.changed = false;
    }

    private IEnumerator fpcChangeText(TMP_Text shotCaption, float delaySeconds, float holdSeconds, string text)
    {
        yield return new WaitForSeconds(delaySeconds);
        shotCaption.fontStyle = FontStyles.Italic;
        fpcTextDone = false;
        shotCaption.text = text;
        yield return new WaitForSeconds(holdSeconds);
        shotCaption.fontStyle = FontStyles.Normal;
        shotCaption.text = " ";
        fpcTextDone = true;
    }

    //consolidate this later
    private IEnumerator fpc1ChangeText(TMP_Text shotCaption, float holdSeconds, string text)
    {
        shotCaption.fontStyle = FontStyles.Italic;
        shotCaption.text = text;
        yield return new WaitForSeconds(holdSeconds);
        shotCaption.fontStyle = FontStyles.Normal;
        shotCaption.text = " ";
    }
    

    private IEnumerator delayMcheck()
    {
        yield return new WaitForSeconds(5f);
        if (handScript.maybe == true && firstMaybe == true && secondMaybe == false) {
            string n3 = "...";
            StartCoroutine(customChangeText(fpcCaption, 2.5f, 2f, n3));
        }
    }

}