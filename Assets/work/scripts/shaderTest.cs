using UnityEngine;

public class shaderTest : MonoBehaviour
{

    void Start()
    {

        GetComponent<Renderer>().material.shader = Shader.Find("Custom/vertexShader");
    }
}
