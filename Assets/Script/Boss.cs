using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    private Dictionary<int,Vector3> initialPositions;
    private bool canChange, canAttack;
    private int cont;
    private float specialAttackTime, attackWait;

    public Boss(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        health *= manager.getDifficulty();  //Se multiplica la vida del enemigo por la dificultad
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, health);
        stats.Add(Stat.Strength, 1);
        stats.Add(Stat.Defense, 1);
        //healthBar.fillAmount = 1;
        attackTime = 0;
        attackWait = 0;
        specialAttackTime = 0;
        cont = 0;
        timer = 0;
        initialPositions = new Dictionary<int, Vector3>();
        initialPositions.Add(1, transform.position);
        initialPositions.Add(2, transform.position);
        initialPositions.Add(3, transform.position);
        initialPositions.Add(4, transform.position);
        canChange = false;
        canAttack = true;
        attacking = false;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Validacion por si la vida del enemigo es cero
        health = GetStatValue(Stat.Health);
        if ((GetStatValue(Stat.Health) == 0) || (player.GetStatValue(Stat.Health) == 0))
        {
            GetComponent<Animator>().SetBool("Attacking", false);
            canAttack = false;
            speed = 0;
            timer += Time.deltaTime;
            if (GetStatValue(Stat.Health) == 0)
            {
                GetComponent<Animator>().SetBool("dead", true); //BOOL PARA ANIMACION DE MUERTE

                if (timer >= 1) //Este tiempo se modifica según la duración de la animación de muerte
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (attacking /*&& canAttack*/)
        {
            attackTime += Time.deltaTime;
        }

        //Se valida esto para quitar la animcacion de ataque cuando termine y no cortarla en plena ejecucion
        if ((attackTime >= 1f) || (!attacking && attackTime != 0))
        {
            GetComponent<Animator>().SetBool("Attacking", false);  //BOOL PARA ANIMACION DE ATAQUE
            attackTime = 0;
            attacking = false;
            canAttack = false;
        }

        if (player.transform.position.x <= transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        /*
         Porcion de codigo encargada del ataque del jefe al player
         */

        if (canChange)  //Se cambia la posicion inicial del boss para cambiar el lugar donde esta estatico por mas tiempo
        {
            initialPosition = initialPositions[Random.Range(1, 5)];
            canChange = false;
        }

        Vector3 target = initialPosition;

        attackWait += Time.deltaTime;

        if ((attackWait >= 3f) && (canAttack))
        {
            target = player.transform.position;
        }

        if (attackWait >= 15f)
        {
            attackWait = 0;
        }

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);

        Debug.DrawRay(transform.position, forward, Color.red);

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if ((target != initialPosition && distance < attackkRadius) || attacking)
        {
            //Atacar detenido
        }
        else
        {
            if (dir.x > 0)  //Validacion para que la animacion vaya con respecto a la direccion
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            //Movimiento hacia el objetivo
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir * speed * Time.deltaTime);
        }

        if (target == initialPosition && distance < 1.5f)  //Validacion para que al estar muy cerca de su posicion inicial retorne a ella y no se quede en un bucle intentando llegar
        {
            transform.position = initialPosition;
            canAttack = true;
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    public override void Attack(Entity player)
    {
        attacking = true;
        GetComponent<Animator>().SetBool("Attacking", true);
        if (attackTime >= 0.6f)    //Este tiempo de ataque se modifica según la duracion de la animacion del ataque
        {
            attackTime = 0;
            if ((player.GetStatValue(Stat.Health) > 0) && (GetStatValue(Stat.Health) > 0))
            {
                Debug.Log("DAÑADO");
                player.TakeDamage(GetStatValue(Stat.Strength));
            }
            canAttack = false;
            canChange = true;
            attackWait = 0;
        }

    }

    void SpecialAttack(Player player)
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackkRadius);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            /*
             * Codigo comentado: para que el boss vuelva a su punto de inicio
             */
            //canAttack = false;
            //GetComponent<Animator>().SetBool("Attacking", canAttack);
            player.Attack(this);
        }
        else if (collision.transform.tag == "Player")
        {
            if ((attackWait >= 3) && canAttack)
            {
                Attack(player);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if ((attackWait >= 3) && canAttack)
            {
                Attack(player);
            }
        }
    }

}
