using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Integrations.Match3;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float maxSpeed = 10f;
    public float currentSpeed;
    public Vector3 mouseDelta = Vector3.zero;

    private Vector3 lastMousePosition = Vector3.zero;
    // Start is called before the first frame update

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameSpecification.Gamediff);
        mouseDelta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;
        if ((Mathf.Abs(transform.position.x) >= 800) || (Mathf.Abs(transform.position.y) >= 500)) transform.position = Vector2.zero;
        if( (Mathf.Abs( Mathf.Abs(transform.position.x) - 643 ) <= 20) && (Mathf.Abs(Mathf.Abs(transform.position.y) - 367) <= 20))
            {
            transform.position = Vector2.zero;
            rigidbody.velocity = Vector2.zero;
            float t = 0;
            while (t < 2f) t += Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if ((collision.gameObject.name == "malle"))
        {
            Debug.Log(collision.gameObject.name);

            Ball ball = collision.gameObject.GetComponent<Ball>();
            Vector2 direction = collision.contacts[0].point - (new Vector2(transform.position.x, transform.position.y));
            float effort = mouseDelta.magnitude;

            rigidbody.AddForce(direction * 0.5f * effort, ForceMode2D.Impulse);
        }
        else if ((collision.gameObject.name == "malle2") || (collision.gameObject.name == "mallenemy") || (collision.gameObject.name == "mallenemy2"))
        {
            Debug.Log(collision.gameObject.name);

            Ball ball = collision.gameObject.GetComponent<Ball>();
            Vector2 direction = collision.contacts[0].point - (new Vector2(transform.position.x, transform.position.y));

            rigidbody.AddForce(direction * 1f, ForceMode2D.Impulse);
        }
    }
}
