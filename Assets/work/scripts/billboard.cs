using UnityEngine;

public class billboard : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
        Vector3 targetDir = transform.position - cameraTransform.position;
        targetDir.y = 0;
        
        if (targetDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetDir);
        }

        
    }
}
