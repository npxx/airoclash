using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kfc1 : MonoBehaviour
{
    public GameObject Ball;
    public GameObject l1;
    public GameObject l2;
    public GameObject r1;
    public GameObject r2;

    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float diffspeed = (GameSpecification.Gamediff <= 1) ? 2f : 0.4f;

        if ((Mathf.Abs(Mathf.Abs(transform.position.x) - 643) <= 50) || (Mathf.Abs(Mathf.Abs(transform.position.y) - 367) <= 50))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.position.normalized * (-1f)); ;
        }

        /*float h = 0f, v = 0f;
        if (Input.GetKey(KeyCode.T)) v = 1f; else if (Input.GetKey(KeyCode.G)) v = -1f;
        if (Input.GetKey(KeyCode.F)) h = -1f; else if (Input.GetKey(KeyCode.H)) h = 1f;*/

        if (transform.position.x >= -72) transform.position = new Vector2(-72, transform.position.y);
        if (transform.position.x <= -624) transform.position = new Vector2(-624, transform.position.y);

        if (transform.position.y <= -360) transform.position = new Vector2(transform.position.x, -360);
        if (transform.position.y >= 360) transform.position = new Vector2(transform.position.x, 360);

        //Debug.Log("Why not move?");
        //Debug.Log(Ball.transform.position.y);

        if (Ball.transform.position.x <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-610, Ball.transform.position.y), diffspeed);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-400, Ball.transform.position.y), diffspeed);
        
    }
}
