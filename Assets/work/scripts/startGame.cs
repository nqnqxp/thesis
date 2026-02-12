using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour
{
    public Animator textAnim;
    public Button startButtonn;

    public GameObject ant1;
    public GameObject ant2;
    public bool gameStarted;
    
    public void startGameButton()
    {
        StartCoroutine(startButton());
    }

    private IEnumerator startButton()
    {
        textAnim.SetBool("startGame", true);
        gameStarted = true;
        startButtonn.interactable = false;
        yield return new WaitForSeconds(1f);
        ant1.gameObject.SetActive(true);
        yield return new WaitForSeconds(5.83f);
        ant1.gameObject.SetActive(false);
        ant2.gameObject.SetActive(true);
    }


}
