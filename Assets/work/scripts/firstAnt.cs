using UnityEngine;

public class firstAnt : MonoBehaviour
{
    public Transform centerPoint;
    public Transform startPoint;

    public float speed = -1f;
    private float radius;
    private float angle = 0f;

    private Vector3 lastPosition;

    void Start()
    {
        Vector3 calculatedRadius = centerPoint.position - startPoint.position;
        radius = calculatedRadius.magnitude;
        lastPosition = startPoint.position;
    }

    void Update()
    {
        Debug.Log(radius);
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.position.y;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        Vector3 newPosition = new Vector3(x, y, z);
        transform.position = newPosition;

        Vector3 direction = newPosition - lastPosition;

        if (direction.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        lastPosition = newPosition;

        angle += speed * Time.deltaTime;

    }

}
