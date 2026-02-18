using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour
{
    public Animator textAnim;
    public Button startButtonn;

    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;
    public bool gameStarted;

    public AudioSource buttonSound;
    
    public void startGameButton()
    {
        StartCoroutine(startButton());
        buttonSound.Play();
        startButtonn.interactable = false;
    }

    private IEnumerator startButton()
    {
        textAnim.SetBool("startGame", true);
        gameStarted = true;
        yield return new WaitForSeconds(1f);
        ant1.gameObject.SetActive(true);
        ant2.gameObject.SetActive(true);
        ant3.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        ant1.gameObject.SetActive(false);
        ant2.gameObject.SetActive(false);
        ant3.gameObject.SetActive(false);
    }


}
