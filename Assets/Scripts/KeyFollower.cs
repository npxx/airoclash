using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyFollower : MonoBehaviour
{
    public GameObject Ball;
    public GameObject l1;
    public GameObject l2;
    public GameObject r1;
    public GameObject r2;
    public Rigidbody2D rb;
    public Rigidbody2D rbthis;
    bool move = true;

    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {    
    }

    private void FixedUpdate()
    {
    }
    // Update is called once per frame
    void Update()
    {
        rbthis = GetComponent<Rigidbody2D>();
        Debug.Log(rbthis);
        rb = Ball.gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log(rb.velocity.magnitude);
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        float diffspeed = (GameSpecification.Gamediff <= 1) ? 0.5f : 2f;


        if (transform.position.x <= 90) transform.position = new Vector2(90, transform.position.y);
        if (transform.position.x >= 624) transform.position = new Vector2(624, transform.position.y);

        if (transform.position.y <= -360) transform.position = new Vector2(transform.position.x, -360);
        if (transform.position.y >= 360) transform.position = new Vector2(transform.position.x, 360);

        if (Ball.transform.position.x >= 0)
        {
            if ((GameSpecification.Gamediff == 2) && move == true)
            {
                if (rb.velocity.magnitude <= 45f) transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x + 10, Ball.transform.position.y), 2f);
                else transform.position = Vector2.MoveTowards(transform.position, new Vector2(597, Ball.transform.position.y), 2f);
            }
            else if (move == true)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(597, Ball.transform.position.y), diffspeed);

        }
        else if (move == true)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Random.value * 40 + 200, l1.transform.position.y), diffspeed);

        if (GameSpecification.Gamediff == 0)
        {
            if (Mathf.Floor(Timer.timeRemaining) % 8 == 0)
            {
                //rbthis.AddForce(new Vector2(Ball.transform.position.x, Ball.transform.position.y) * 10f, ForceMode2D.Impulse);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), 3f);
                move = false;
                float t = 0;
                while(t<2f) t += Time.deltaTime;
                move = true;
            }
        }
        else if(GameSpecification.Gamediff == 1)
        {
            if (Mathf.Floor(Timer.timeRemaining) % 5 == 0)
            {
                //rbthis.AddForce(new Vector2(Ball.transform.position.x, Ball.transform.position.y), ForceMode2D.Impulse);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), 3f);
                move = false;
                float t = 0;
                while (t < 2f) t += Time.deltaTime;
                move = true;
            }
        }
        else
          if (Mathf.Floor(Timer.timeRemaining) % 3 == 0)
            {
            //rbthis.AddForce(new Vector2(Ball.transform.position.x, Ball.transform.position.y), ForceMode2D.Impulse);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Ball.transform.position.x, Ball.transform.position.y), 3f);
            move = false;
            float t = 0;
            while (t < 2f) t += Time.deltaTime;
            move = true;
        }
    }

}
