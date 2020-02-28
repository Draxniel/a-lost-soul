using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Vector3 target;
    public Boss boss;
    public Player player;
    private int speed, damage;

    public Missile (Vector3 target)
    {
        this.target = target;
        damage = 1 * boss.GetDamageMultiplier();
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
        Vector3 bossPosition = new Vector3(boss.transform.position.x - 0.1f, boss.transform.position.y, boss.transform.position.z);
        transform.position = boss.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
}
