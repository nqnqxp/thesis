using UnityEngine;

public class followHand : MonoBehaviour
{

    public Camera shot6Cam;

    private float distance;
    private Plane movePlane;
    private Ray ray;
    private Vector3 hitPoint;

    public Vector2 centerPoint = new Vector2(0.5f, 0.5f);
    public float ellipseWidth = 0.3f;
    public float ellipseHeight = 0.25f;

    private Vector2 mousePosition;
    private Vector2 offset;

    void Update()
    {

        mousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
        offset = mousePosition - centerPoint;

        float distanceSquared = (offset.x * offset.x) / (ellipseWidth * ellipseWidth) + (offset.y * offset.y) / (ellipseHeight * ellipseHeight);

        if (distanceSquared > 1.0f)
        {
            float angle = Mathf.Atan2(offset.y, offset.x);
            mousePosition.x = centerPoint.x + Mathf.Cos(angle) * ellipseWidth;
            mousePosition.y = centerPoint.y + Mathf.Sin(angle) * ellipseHeight;
        }

        Vector3 clampedMousePixels = new Vector3(mousePosition.x * Screen.width, mousePosition.y * Screen.height, 0);

        movePlane = new Plane(Vector3.up, new Vector3(0, 20.03f, 0));
        ray = shot6Cam.ScreenPointToRay(clampedMousePixels);

        if (movePlane.Raycast(ray, out float distance))
        {
            transform.position = ray.GetPoint(distance);
        }

    }

}