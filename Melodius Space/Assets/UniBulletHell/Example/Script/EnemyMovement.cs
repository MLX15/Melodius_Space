using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Boundary {
        public float xMin, xMax;
    }

     public float dodge;
    public float smoothing;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent <Rigidbody2D> ();
        StartCoroutine (Evade ());
    }

    IEnumerator Evade()
    {

        while (true)
        {
            targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate ()
    {
        Vector3 pos = transform.position;
        float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector2 (newManeuver, rb.velocity.y);
        rb.position = new Vector2 (
             Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax), rb.position.y
        );
    }
}
