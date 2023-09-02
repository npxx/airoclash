using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoZo : MonoBehaviour
{
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Debug.Log("hit");
            scoreTrigger.Invoke();
        ball.transform.position = Vector3.zero;
        ball.rigidbody.velocity = Vector3.zero;
        }
    }

}
