using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour
{
    public Animator textAnim;
    public Button startButtonn;

    public GameObject ants;
    
    public void startGameButton()
    {
        StartCoroutine(startButton());
    }

    private IEnumerator startButton()
    {
        textAnim.SetBool("startGame", true);
        startButtonn.interactable = false;
        yield return new WaitForSeconds(1f);
        ants.gameObject.SetActive(true);
    }


}
