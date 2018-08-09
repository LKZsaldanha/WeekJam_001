using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	//scene name
	public string sceneToGo;
    public float timerToGo;
    

    //changes scene
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "NPC")
        {
            StartCoroutine(Countdown());
        }

    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timerToGo);
        SceneManager.LoadScene(sceneToGo);     
    }

 }
