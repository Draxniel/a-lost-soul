using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : Enemy
{

    LargeEnemy(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        health = 10; //VIDA INICIAL DEL ENEMIGO
        health *= manager.getDifficulty();
        damageMultiplier = manager.getDifficulty();
        maxhealth = health;
        //Se multiplica la vida del enemigo por la dificultad
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, health);
        stats.Add(Stat.Strength, (2 * damageMultiplier));
        stats.Add(Stat.Defense, 1);
        attackTime = 0;
        attacking = false;
        canAttack = false;
        timer = 0;
        initialPosition = transform.position;
        attackWait = 3;
        //Posicion inicial igual a posicion actual                             
        visionRadius = 150;                              
        attackkRadius = 60;                               
        speed = 40;
        enemyHealth.setMaxHealth(health);
        enemyHealth.setActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Validacion por si la vida del enemigo es cero
        //health = GetStatValue(Stat.Health);
        if (GetStatValue(Stat.Health) == 0 || (player.GetStatValue(Stat.Health) == 0))
        {
            GetComponent<Animator>().SetBool("attack", false);
            speed = 0;
            timer += Time.deltaTime;
            if (GetStatValue(Stat.Health) == 0)
            {
                GetComponent<Animator>().SetBool("dead", true); //BOOL PARA ANIMACION DE MUERTE
                if (!(SoundController.isPlaying()))
                {
                    SoundController.playOneShot(deathSound);
                }
                if (timer >= 1) //Este tiempo se modifica según la duración de la animación de muerte
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (attacking)
        {
            attackTime += Time.deltaTime;
        }

        //Se valida esto para quitar la animcacion de ataque cuando termine y no cortarla en plena ejecucion
        if (attackTime >= 0.8f)
        {
            GetComponent<Animator>().SetBool("attack", false);  //BOOL PARA ANIMACION DE ATAQUE
            attackTime = 0;
            attacking = false;
            attackWait = 0;
            canAttack = false;
        }

        /*
         Procion de código encargada del cooldown de ataque del enemigo
         */
        if (!canAttack)
        {
            attackWait += Time.deltaTime;
        }

        if (attackWait >= 1f)
        {
            canAttack = true;
            attackWait = 0;
        }

        //VOLTEAR LA SKIN DEPENDIENDO DE LA SKIN DEL PLAYER
        if (player.transform.position.x <= transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        /*
         Porcion de codigo encargada de la persecucion del enemigo al player
         */

        Vector3 target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            visionRadius,
            1 << LayerMask.NameToLayer("Player"));

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);

        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;
        dir.y = 0;  //Colocamos Y en cero ya que no se deben mover en esa coordenada 

        if (target != initialPosition && distance < attackkRadius)
        {
            //Attack
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
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir * speed * Time.deltaTime);
            //Animaciones de movimiento
        }

        if (target == initialPosition && distance < 1f)  //Validacion para que al estar muy cerca de su posicion inicial retorne a ella y no se quede en un bucle intentando llegar
        {
            transform.position = initialPosition;
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    public override void Attack(Entity player)
    {
        attacking = true;
        GetComponent<Animator>().SetBool("attack", true);
        if (attackTime >= 0.4f)    //Este tiempo de ataque se modifica según la duracion de la animacion del ataque
        {
            attackTime = 0;
            SoundController.playOneShot(attackSound);
            SoundController.playOneShot(weaponSound);
            if ((player.GetStatValue(Stat.Health) > 0) && (GetStatValue(Stat.Health) > 0))
            {
                player.TakeDamage(GetStatValue(Stat.Strength));
                canAttack = false;
            }
            GetComponent<Animator>().SetBool("attack", false);  //BOOL PARA ANIMACION DE ATAQUE
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            player.Attack(this);
        }
        else if ((collision.transform.tag == "Player") && (player.isPlayerAlive()))
        {
            if (canAttack)
            {
                Attack(player);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackkRadius);
    }

}
