using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public float directionThreshold = 0.1f;
    public int requiredDirectionChanges = 3;

    private float lastMouseX = 0f;
    private int directionChanges = 0;
    private int lastDirection = 0;

    public Animator animator;

    public Image hand;
    public List<Sprite> spritesToRandomize;

    public bool shaken;
    public bool changed;

    public bool camChanged;

    void Update()
    {
        if (camChanged == true)
        {
            float mouseDeltaX = Input.GetAxis("Mouse X");
            DetectShake(mouseDeltaX);

            if (shaken == true && changed == false)
            {
                if(animator.GetCurrentAnimatorStateInfo(0).IsName("noshake") )
                {
                    ApplyRandomSprite();
                    changed = true;
                }
            }
        }
        
    }

    void DetectShake(float deltaX)
    {
        if (Mathf.Abs(deltaX) < directionThreshold)
            return;

        int currentDirection = deltaX > 0 ? 1 : -1;

        if (lastDirection != 0 && currentDirection != lastDirection)
        {
            directionChanges++;

            if (directionChanges >= requiredDirectionChanges && shaken == false)
            {
                Debug.Log("shaken");
                animator.Play("shakeB");
                shaken = true;
                directionChanges = 0;
            }
        }
        lastDirection = currentDirection;
    }

    public void ApplyRandomSprite()
    {
        int randomIndex = Random.Range(0, spritesToRandomize.Count);
        hand.sprite = spritesToRandomize[randomIndex];
    }
}
