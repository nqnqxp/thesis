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
    public TMP_Text shot7Caption;
    public TMP_Text shot8Caption;
    public TMP_Text shot9Caption;
    public TMP_Text shot10Caption;
    public TMP_Text shot11Caption;

    public List<string> idleTexts;

    public test handScript;

    //shot6 bools
    public bool resetOdd;
    public bool resetEven;

    //shot7-9 bool
    public bool resetS7;
    public bool resetS81;
    public bool resetS91;
    public bool resetS82;
    public bool resetS92;
    public bool resetS83;
    public bool resetS93;
    public bool resetS84;
    public bool resetS94;
    public bool resetS85;
    public bool shot8FirstTime = true;
    public bool shot9FirstTime = true;
    public bool shot8SecondTime = true;
    public bool shot9SecondTime = true;
    public bool shot8ThirdTime = true;
    public bool shot9ThirdTime = true;
    public bool shot8FourthTime = true;

    //shot10 bool
    public bool resetS10;

    public bool resetS11;

    //prototype4 bools
    public bool fpcTextDone;
    private bool n1Done;
    public bool firstMaybe;
    public bool secondMaybe;

    //public GameObject shotW;
    public GameObject shot6;
    public GameObject shot7;
    public shot7Events shot7script;
    public GameObject shot8;
    public GameObject shot9;
    public GameObject shot10;
    public GameObject shot11;
    


    void Update()
    {
        //loves me, loves me not
        if (shot6.gameObject.activeSelf == true)
        {
            if (pickLimbs.dragCount > 0)
            {
                if (pickLimbs.lovesMe == true && resetOdd == false)
                {
                    string shot6Text1 = "She loves me...";
                    StartCoroutine(fpc1ChangeText(shot6Caption, 2f, shot6Text1));
                    resetEven = false;
                    resetOdd = true;
                }
                if (pickLimbs.lovesMe == false && resetEven == false)
                {
                    string shot6Text2 = "She loves me not...";
                    StartCoroutine(fpc1ChangeText(shot6Caption, 2f, shot6Text2));
                    resetOdd = false;
                    resetEven = true;
                }
            }

        }

        if (shot7.gameObject.activeSelf == true && shot7script.localShotStarted == true && resetS7 == false)
        { 
            string shot7text = "Resist seeking prognostications, or the course will start to consume you.";
            StartCoroutine(changeText(shot7Caption, 5f, 4f, shot7text));
            resetS7 = true;
        }

        if (shot8.gameObject.activeSelf == true && resetS81 == false && shot8FirstTime == true)
        { 
            string shot8text = "What do you think these answers will provide you?";
            StartCoroutine(changeText(shot8Caption, 1f, 2f, shot8text));
            //StartCoroutine(delayboolChange(3f, boolChange(resetS81)));
            //StartCoroutine(delayboolChange(3f, () => boolChange(shot8FirstTime)));
            resetS81 = true;
        }

        if (shot9.gameObject.activeSelf == true && resetS91 == false && shot9FirstTime == true)
        { 
            string shot9text = "...I don't know";
            StartCoroutine(changeText(shot9Caption, 2f, 1.5f, shot9text));
            resetS91 = true;
            shot8FirstTime = false;
        }

        if (shot10.gameObject.activeSelf == true && resetS10 == false)
        { 
            string shot10text = "You believe in fate?";
            StartCoroutine(changeText(shot10Caption, 2f, 1.5f, shot10text));
            resetS10 = true;
            shot9FirstTime = false;
        }

        // if (shot8.gameObject.activeSelf == true && resetS82 == false && shot8FirstTime == false)
        // { 
        //     string shot8text = "You believe in fate?";
        //     StartCoroutine(changeText(shot8Caption, 2f, 1.5f, shot8text));
        //     resetS82 = true;
        //     shot9FirstTime = false;
        // }

        if (shot9.gameObject.activeSelf == true && resetS92 == false && shot9FirstTime == false)
        { 
            string shot9text = "...";
            StartCoroutine(changeText(shot9Caption, 2f, 1.5f, shot9text));
            resetS92 = true;
            shot8SecondTime = false;
        }

        if (shot8.gameObject.activeSelf == true && resetS83 == false && shot8SecondTime == false)
        { 
            string shot8text1 = "That's right.";
            StartCoroutine(changeText(shot8Caption, 2f, 1.5f, shot8text1));
            string shot8text2 = "Inevitability...";
            StartCoroutine(changeText(shot8Caption, 4.5f, 1.5f, shot8text2));
            resetS83 = true;
        }

        if (shot11.gameObject.activeSelf == true && resetS11 == false)
        { 
            string shot11text = "...The hidden rules behind what you see as patternless events.";
            StartCoroutine(changeText(shot11Caption, 1.5f, 2.5f, shot11text));
            string shot11text2 = "Events that lead to one destination.";
            StartCoroutine(changeText(shot11Caption, 5.5f, 2f, shot11text2));
            resetS11 = true;
            shot9SecondTime = false;
            
        }

        if (shot9.gameObject.activeSelf == true && resetS93 == false && shot9SecondTime == false)
        { 
            string shot9text = "I... don’t want to.";
            StartCoroutine(changeText(shot9Caption, 2f, 1.5f, shot9text));
            resetS93 = true;
            shot8ThirdTime = false;
        }

        if (shot8.gameObject.activeSelf == true && resetS84 == false && shot8ThirdTime == false)
        { 
            string shot8text1 = "So, free will...";
            StartCoroutine(changeText(shot8Caption, 2f, 1.5f, shot8text1));
            string shot8text2 = "...that one’s choices are really their own.";
            StartCoroutine(changeText(shot8Caption, 5f, 2f, shot8text2));
            string shot8text3 = "Choosing to eat bread or porridge.";
            StartCoroutine(changeText(shot8Caption, 8.5f, 2f, shot8text3));
            string shot8text4 = "To visit a garden or a cemetery.";
            StartCoroutine(changeText(shot8Caption, 12f, 2f, shot8text4));
            string shot8text5 = "By making such trivial decisions, we pretend to be masters of our destiny.";
            StartCoroutine(changeText(shot8Caption, 15.5f, 3f, shot8text5));
            resetS84 = true;
            shot9ThirdTime = false;
        }

        if (shot9.gameObject.activeSelf == true && resetS94 == false && shot9ThirdTime == false)
        { 
            string shot9text = "... I don’t know what my destiny is.";
            StartCoroutine(changeText(shot9Caption, 2f, 1.5f, shot9text));
            resetS94 = true;
            shot8FourthTime = false;
        }

        if (shot8.gameObject.activeSelf == true && resetS85 == false && shot8FourthTime == false)
        { 
            string shot8text1 = "Yes, you do.";
            StartCoroutine(changeText(shot8Caption, 2f, 1.5f, shot8text1));
            string shot8text2 = "Everyone’s destiny is ultimately the same.";
            StartCoroutine(changeText(shot8Caption, 5f, 2f, shot8text2));
            string shot8text3 = "Even mine.";
            StartCoroutine(changeText(shot8Caption, 8.5f, 1.5f, shot8text3));
            string shot8text4 = "If the inquisitiveness takes you first, use this instead, if you’d like.";
            StartCoroutine(changeText(shot8Caption, 12.5f, 2.5f, shot8text4));
            resetS85 = true;
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

    void boolChange(bool boolname)
    {
        boolname = false;
    }

    private IEnumerator delayboolChange(float seconds, System.Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback.Invoke();
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
        //fpcTextDone = false;
        yield return new WaitForSeconds(wait);
        caption.text = text;
        yield return new WaitForSeconds(stay);
        caption.text = " ";
        //fpcTextDone = true;
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