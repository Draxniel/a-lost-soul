using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Vector3 target;
    public Boss boss;
    public Player player;
    private int speed;

    public Missile (Vector3 target)
    {
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 250;
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(target, transform.position);

        Vector3 forward = transform.TransformDirection(target - transform.position);

        Debug.DrawRay(transform.position, forward, Color.red);

        Vector3 dir = (target - transform.position).normalized;

        GetComponent<Rigidbody2D>().MovePosition(transform.position + dir * speed * Time.deltaTime);

        Debug.DrawLine(transform.position, target, Color.green);

    }

    public void ResetPosition()
    {
        transform.position = boss.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            player.TakeDamage(1);
        }
    }
}
