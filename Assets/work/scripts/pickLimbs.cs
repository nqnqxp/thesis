using UnityEngine;

public class pickLimbs : MonoBehaviour
{
    Vector3 mousePosition;
    
    public Rigidbody rb;

    public Camera shot6;

    public static int dragCount = 0;

    public bool dragged;

    public bool lovesMe;

    void enablePhysics()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
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
            
        }
        
        enablePhysics();
        transform.position = shot6.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }


    void Update()
    {
        //Debug.Log(dragCount);
        //Debug.Log(lovesMe);

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
