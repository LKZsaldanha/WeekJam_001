using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckTargetDistance : MonoBehaviour {

    public Transform target;
    public float alertDistance;
    public float limitDistance;
    public float currentDistance;
    public Text farAway;
    

    public float farAwayTime = 3;
    private float lastFarAwayTime = 3;

    public void Start()
    {
        lastFarAwayTime = farAwayTime;
    }

    private void Update()
    {
        currentDistance = Vector2.Distance(transform.position, target.position);
                
        if(currentDistance > alertDistance)
        {
            if(currentDistance > limitDistance)
            {
                DangerVisual();
                
            }
            else
            {
                AlertVisual();
            }
        }
        else
        {
            NormalVisual();
        }
    }


    private void NormalVisual()
    {
        Color tmp = GetComponent<SpriteRenderer>().color = Color.green;
        tmp.a = .6f;
        GetComponent<SpriteRenderer>().color = tmp;
        farAway.enabled = false;
        farAwayTime = lastFarAwayTime;
    }

    private void AlertVisual()
    {
        Color tmp = GetComponent<SpriteRenderer>().color = Color.yellow;
        tmp.a = .6f;
        GetComponent<SpriteRenderer>().color = tmp;
        farAway.enabled = false;
        farAwayTime = lastFarAwayTime;
    }

    private void DangerVisual()
    {
        Color tmp = GetComponent<SpriteRenderer>().color = Color.red;
        tmp.a = .6f;
        GetComponent<SpriteRenderer>().color = tmp;
        farAway.enabled = true;
        farAwayTime -= Time.deltaTime;
        

        if (farAwayTime < 0)
        {
            farAway.text = "Sorry, server desynchronized\n Press any key to try again";
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            farAway.text = farAwayTime.ToString("F2");
        }
    }
}
