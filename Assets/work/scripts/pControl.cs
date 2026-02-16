using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{

	[SerializeField] private float speed = 3f;
    [SerializeField] private bool backMovement = false;
    //[SerializeField] private Camera fpc;

	Animator animator;

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

    }

}