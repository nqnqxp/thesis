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
        Animator anim = GetComponent<Animator>();
        anim.Play("Base Layer.walk", 0, Random.value);
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;
        Vector3 newPosition = new Vector3(x, centerPoint.position.y, z);

        Vector3 tangent = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));

        transform.position = newPosition;

        Vector3 forwardDirection;
        if (speed >= 0)
        {
            forwardDirection = tangent;
        }
        else
        {
            forwardDirection = -tangent;
        }
        transform.rotation = Quaternion.LookRotation(forwardDirection);
    }
}



