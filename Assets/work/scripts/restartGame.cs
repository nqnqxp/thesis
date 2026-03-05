using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            pickLimbs.dragCount = 0;
            restart();
        }
    }

    public void restart()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
