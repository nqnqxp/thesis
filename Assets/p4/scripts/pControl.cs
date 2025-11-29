using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{

	[SerializeField] private float speed = 3f;
    [SerializeField] private bool backMovement = false;
    [SerializeField] private Camera fpc;

	Animator animator;

    /*
    public float shakeThreshold = 100f;
    public float shakeDuration = 0.5f;

    private Vector2 startMousePosition;
    private float startTime;
    private bool isTracking = false;

    */

	void Start()
	    {
	        animator = gameObject.GetComponent<Animator>();
	    }

    void Update()
    {
        if (backMovement == true)
        {
            if (Input.GetKey(KeyCode.A)) {
                transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
                
                animator.SetBool("isWalking", true);
            }
            
            if (Input.GetKeyUp(KeyCode.A)) {
                animator.SetBool("isWalking", false);
            }
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
			
			animator.SetBool("isWalking", true);

		}
		
		if (Input.GetKeyUp(KeyCode.D)) {
			animator.SetBool("isWalking", false);
		}
		
        /*8ball

        Vector2 currentMousePosition = Input.mousePosition;

        if (isTracking == false)
        {
            startMousePosition = currentMousePosition;
            startTime = Time.time;
            isTracking = true;
        }

        if (isTracking == true)
        {
            float elapsedTime = Time.time - startTime;
            float netHorizontalMovement = currentMousePosition.x - startMousePosition.x;

            float absoluteMovement = Mathf.Abs(netHorizontalMovement);

            if (absoluteMovement >= shakeThreshold)
            {
                //shaked
                //trigger animation
                Debug.Log("shaked");
                ResetTracking();
            }

            else if (elapsedTime >= shakeDuration)
            {
                ResetTracking();
            }
        }
        */
        
    }

    /*
    private void ResetTracking()
    {
        isTracking = false; // Next Update() loop will set a new start position and time
    }
    */
}