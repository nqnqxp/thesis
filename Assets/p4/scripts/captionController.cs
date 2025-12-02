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

    public List<string> idleTexts;

    public test camBool;

    public bool fpcTextDone;
    private bool n1Done;

    void Update()
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

        //FPC/Mouse Stuff

        if (camBool.camChanged == true)
        {
            if (n1Done == false)
            {
                string n1 = "am I ready to visit ******?";
                StartCoroutine(fpcChangeText(2, n1));
                n1Done = true;
            }

            if(fpcTextDone == true)
            {
                MouseTimer();
            }

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

    private IEnumerator changeText(TMP_Text caption, float seconds, string text)
    {
        caption.text = text;
        yield return new WaitForSeconds(seconds);
        caption.text = " ";
    }

    private IEnumerator fpcChangeText(float seconds, string text)
    {
        yield return new WaitForSeconds(1.5f);
        fpcCaption.fontStyle = FontStyles.Italic;
        fpcTextDone = false;
        fpcCaption.text = text;
        yield return new WaitForSeconds(seconds);
        fpcCaption.fontStyle = FontStyles.Normal;
        fpcCaption.text = " ";
        fpcTextDone = true;
    }

}