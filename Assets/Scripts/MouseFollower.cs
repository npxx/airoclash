using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 cp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cp.x, cp.y);


        if (transform.position.x >= -72) transform.position = new Vector2(-72, transform.position.y);
        if (transform.position.x <= -624) transform.position = new Vector2(-624, transform.position.y);
        if (transform.position.y <= -360) transform.position = new Vector2(transform.position.x, -360);
        if (transform.position.y >= 360) transform.position = new Vector2(transform.position.x, 360);

        if ((Mathf.Abs(Mathf.Abs(transform.position.x) - 643) <= 50) || (Mathf.Abs(Mathf.Abs(transform.position.y) - 367) <= 50))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.position.normalized * (-1f)); ;
        }

    }
}
