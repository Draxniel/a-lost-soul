using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Player player;
    public DataManager manager;
    public int health, speed;
    public float visionRadius;
    public float attackkRadius;
    private bool attacking, canAttack;
    private float attackTime, timer;
    private Vector3 initialPosition;

    public Enemy(int health, int strength, int defense) : base(health, strength, defense)
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
        attacking = false;
        timer = 0;
        initialPosition = transform.position; //Posicion inicial igual a posicion actual
        //MEDIDAS PARA EL MINOTAURO
        /*visionRadius = 150;
        attackkRadius = 60;
        speed = 40;*/
    }

    // Update is called once per frame
    void Update()
    {
        //Validacion por si la vida del enemigo es cero
        health = GetStatValue(Stat.Health);
        if (GetStatValue(Stat.Health) == 0)
        {
            attacking = false;
            canAttack = false;
            speed = 0;
            timer += Time.deltaTime;
            //Se colocan las animaciones correspondientes
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetBool("dead", true); //BOOL PARA ANIMACION DE MUERTE
            if (timer >= 1) //Este tiempo se modifica según la duración de la animación de muerte
            {
                gameObject.SetActive(false);
            }
        }
        //Porcion de codigo que aumenta el tiempo de ataque
        if (attacking)
        {
            attackTime += Time.deltaTime;
        }
        //Se valida esto para quitar la animcacion de ataque cuando termine y no cortarla en plena ejecucion
        if ((attackTime >= 1) && (!canAttack))  
        {
            GetComponent<Animator>().SetBool("attack", false);  //BOOL PARA ANIMACION DE ATAQUE
            attackTime = 0;
            attacking = false;
        }

        if (player.transform.position.x < transform.position.x)
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
        if (attackTime >= 0.8f)    //Este tiempo de ataque se modifica según la duracion de la animacion del ataque
        {
            attackTime = 0;
            if ((player.GetStatValue(Stat.Health) > 0) && (GetStatValue(Stat.Health) > 0))
            {
                GetComponent<Animator>().SetBool("attack", true);
                player.TakeDamage(GetStatValue(Stat.Strength));
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            player.Attack(this);
        }
        else if (collision.transform.tag == "Player")
        {
            Attack(player);
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
    }

    public override void TakeDamage(int damage)
    {
        if (GetStatValue(Stat.Health) > 0)
        {
            if (damage <= GetStatValue(Stat.Health))
            {
                this.stats[Stat.Health] -= damage;
                return;
            }
            stats[Stat.Health] = 0;
        }
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackkRadius);
    }

}
