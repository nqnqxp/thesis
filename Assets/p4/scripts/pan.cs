using UnityEngine;

public class pan : MonoBehaviour
{
    public Transform sg;

    private float cameraMinZ = 385.3f;
    private float cameraMaxZ = 393.9f;

    private float characterMinZ = 294.9f;
    private float characterMaxZ = 401.2f;

    public float smoothSpeed = 5f;

    void Update()
    {
        float t = Mathf.InverseLerp(characterMinZ, characterMaxZ, sg.position.z);

        float targetCameraZ = Mathf.Lerp(cameraMinZ, cameraMaxZ, t);

        Vector3 camPos = transform.position;
        camPos.z = Mathf.Lerp(camPos.z, targetCameraZ, Time.deltaTime * smoothSpeed);

        transform.position = camPos;
    }
}
