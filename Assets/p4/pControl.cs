using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pControl : MonoBehaviour
{

	[SerializeField] private float speed = 0f;

	Animator animator;

	void Start()
	    {
	        animator = gameObject.GetComponent<Animator>();
        
	    }

    void Update()
    {
		//Quaternion characterRotation = transform.localRotation;

        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
			
			animator.SetBool("isWalking", true);

		}
		
		if (Input.GetKeyUp(KeyCode.D)) {
			animator.SetBool("isWalking", false);
		}
		
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
			
			animator.SetBool("isWalking", true);
		}
		
		if (Input.GetKeyUp(KeyCode.A)) {
			animator.SetBool("isWalking", false);
		}
    }
}