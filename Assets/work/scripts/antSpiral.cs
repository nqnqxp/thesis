using UnityEngine;

public class antSpiral : MonoBehaviour
{
    public Transform centerPoint;
    public float speed = 1f;
    public float radius = 1f;
    public float angle = 0f;

    private Vector3 lastPosition;

    void Start()
    {
        angle = Random.Range(0f, Mathf.PI * 2f);
        lastPosition = transform.position;
    }

    void Update()
    {
        
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
