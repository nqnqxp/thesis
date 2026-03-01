using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class pickLimbs : MonoBehaviour
{
    Vector3 mousePosition;
    
    public Rigidbody rb;

    public Camera shot6;

    public static int dragCount = 0;

    public bool dragged;

    public static bool lovesMe;

    public List<AudioSource> breakSounds;

    public Material[] myMaterials;
    public Material limbTex;
    public Material onHoverTex;

    public handFollowMouse handfollowmouse;
    public followHand fingerFollowScript;

    public bool scriptsStopped;

    void enablePhysics()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    void disablePhysics()
    {
        rb.isKinematic = true;
    }

    public void OnMouseEnter()
    {
        Debug.Log("hovering");
	 	myMaterials[0] = limbTex;
		myMaterials[1] = onHoverTex;
	    gameObject.GetComponent<Renderer>().materials = myMaterials;
    }

    public void OnMouseExit()
    {
        Debug.Log("not hovering");
        myMaterials[0] = limbTex;
		myMaterials[1] = limbTex;
	    gameObject.GetComponent<Renderer>().materials = myMaterials;
    }

    private Vector3 GetMousePos()
    {
        return shot6.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (dragged == false)
        {
            dragCount++;
            dragged = true;

            int randomIndex = Random.Range(0, breakSounds.Count);
            breakSounds[randomIndex].Play();

        }
        
        disablePhysics();


        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = shot6.WorldToScreenPoint(transform.position).z; 
        Vector3 newPos = shot6.ScreenToWorldPoint(screenPoint);
        
        newPos.y = 20.15f;
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        enablePhysics();
    }

    private IEnumerator stopScripts()
    {
        yield return new WaitForSeconds(1.5f);
        handfollowmouse.enabled = false;
        fingerFollowScript.enabled = false;
        //this.enabled = false;
    }

    void Start()
    {
        myMaterials = gameObject.GetComponent<Renderer>().materials;
    }

    void Update()
    {
        if (dragCount == 6 && scriptsStopped == false)
        {
            StartCoroutine(stopScripts());
            scriptsStopped = true;
        }
        if (dragCount % 2 == 0)
        {
            //even
            lovesMe = false;
        }
        else
        {
            //odd
            lovesMe = true;
        }
    }
}
