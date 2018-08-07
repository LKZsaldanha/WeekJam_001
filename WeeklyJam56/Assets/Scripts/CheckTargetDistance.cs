using UnityEngine;

public class CheckTargetDistance : MonoBehaviour {

    public Transform target;
    public float alertDistance;
    public float limitDistance;
    public float currentDistance;

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
    }

    private void AlertVisual()
    {
        Color tmp = GetComponent<SpriteRenderer>().color = Color.yellow;
        tmp.a = .6f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    private void DangerVisual()
    {
        Color tmp = GetComponent<SpriteRenderer>().color = Color.red;
        tmp.a = .6f;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
