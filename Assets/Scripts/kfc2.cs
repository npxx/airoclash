using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Integrations.Match3;
using UnityEngine;

public class kfc2 : MonoBehaviour
{
    public GameObject Ball;
    public GameObject l1;
    public GameObject l2;
    public GameObject r1;
    public GameObject r2;
    bool move = true;

    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(Mathf.Abs(transform.position.x) - 643) <= 50) || (Mathf.Abs(Mathf.Abs(transform.position.y) - 367) <= 50))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.position.normalized * (-1f)); ;
        }
        float diffspeed = (GameSpecification.Gamediff <= 1) ? 0.5f : 2f;

        /*float h = 0f, v = 0f;
        if (Input.GetKey(KeyCode.I)) v = 1f; else if (Input.GetKey(KeyCode.K)) v = -1f;
        if (Input.GetKey(KeyCode.J)) h = -1f; else if (Input.GetKey(KeyCode.L)) h = 1f;*/


        if (transform.position.x <= 90) transform.position = new Vector2(90, transform.position.y);
        if (transform.position.x >= 624) transform.position = new Vector2(624, transform.position.y);

        if (transform.position.y <= -360) transform.position = new Vector2(transform.position.x, -360);
        if (transform.position.y >= 360) transform.position = new Vector2(transform.position.x, 360);

        if (Ball.transform.position.x >= 0)
        {
            if ((GameSpecification.Gamediff >= 1) && move == true)
            {
                if ((Ball.transform.position.y >= 90) && (Ball.transform.position.y <= 240))
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x + 50, Ball.transform.position.y + 50), diffspeed);
                else if ((Ball.transform.position.y) > 240)
                    transform.position = Vector2.MoveTowards(transform.position, Ball.transform.position + new Vector3(80, -80, 0), diffspeed);

                if (Mathf.Abs(transform.position.x - Ball.transform.position.x) >= 20)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Ball.transform.position + new Vector3(50, 0, 0), diffspeed);
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), diffspeed);
                }
            }
            else
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Random.value * 50 + 150f, Random.value * (-100) + 240f), 0.5f) ;
        }

        if (GameSpecification.Gamediff == 0)
        {
            if (Mathf.Floor(Timer.timeRemaining) % 8 == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), 1f);
                move = false;
                float t = 0;
                while (t < 2f) t += Time.deltaTime;
                move = true;
            }
        }
        else if (GameSpecification.Gamediff == 1)
        {
            if (Mathf.Floor(Timer.timeRemaining) % 5 == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), 1f);
                move = false;
                float t = 0;
                while (t < 2f) t += Time.deltaTime;
                move = true;
            }
        }
        else
          if (Mathf.Floor(Timer.timeRemaining) % 3 == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), diffspeed);
            move = false;
            float t = 0;
            while (t < 2f) t += Time.deltaTime;
            move = true;
        }
    }
}
