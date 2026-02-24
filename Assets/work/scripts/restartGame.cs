using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            restart();
        }
    }

    public void restart()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
