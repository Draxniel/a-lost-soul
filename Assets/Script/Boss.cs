using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy
{

    private Dictionary<int,Vector3> initialPositions;
    private bool canChange, specialAttack, walking;
    private int cont, deathSoundActivate = 0 ;
    private float specialAttackTime;
    private Vector3 specialAttackPosition;
    public Missile[] missile;
    public AudioClip laugh, fireball, firebreath;
    private bool fireballSound = true;

    public Boss(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        health = 240;
        speed = 250;
        attackkRadius = 50;
        visionRadius = 300;
        damageMultiplier = manager.getDifficulty();
        health *= damageMultiplier;  //Se multiplica la vida del enemigo por la dificultad
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, health);
        stats.Add(Stat.Strength, 1*damageMultiplier);
        stats.Add(Stat.Defense, 1);
        attackTime = 0;
        attackWait = 0;
        specialAttackTime = 0;
        cont = 0;
        timer = 0;
        initialPositions = new Dictionary<int, Vector3>();
        initialPositions.Add(1, new Vector3(250, 230, 0));
        specialAttackPosition = initialPositions[1];
        initialPositions.Add(2, new Vector3(353, 210, 0));
        initialPositions.Add(3, new Vector3(382, 148, 0));
        canChange = false;
        canAttack = true;
        attacking = false;
        specialAttack = false;
        walking = false;
        initialPosition = transform.position;
        fireballSound = true;
        enemyHealth.setMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.gamePaused) {
            GetComponent<AudioSource>().Pause();
        }
        else{
           GetComponent<AudioSource>().UnPause(); 
        }
        //Validacion por si la vida del enemigo es cero
        health = GetStatValue(Stat.Health);
        if ((GetStatValue(Stat.Health) == 0) || (player.GetStatValue(Stat.Health) == 0))
        {
            if (deathSoundActivate == 1)
            {
                GetComponent<AudioSource>().Pause();
                SoundController.playOneShot(deathSound);
            }
            GetComponent<Animator>().SetBool("Attacking", false);
            canAttack = false;
            speed = 0;
            timer += Time.deltaTime;
            if (GetStatValue(Stat.Health) == 0)
            {
                deathSoundActivate++;
                GetComponent<AudioSource>().Pause();
                GetComponent<Animator>().SetBool("dead", true); //BOOL PARA ANIMACION DE MUERTE
                if (timer >= 3) //Este tiempo se modifica según la duración de la animación de muerte
                {
                    gameObject.SetActive(false);
                    SceneManager.LoadScene("Ending scene", LoadSceneMode.Single);
                    DataManager.saveGame(true);
                    DataSave.saveCurrentGame();
                }
            }
        }

        if (attacking /*&& canAttack*/)
        {
            attackTime += Time.deltaTime;
        }

        //Se valida esto para quitar la animcacion de ataque cuando termine y no cortarla en plena ejecucion
        if ((attackTime >= 0.6f) || (!attacking && attackTime != 0))
        {
            GetComponent<Animator>().SetBool("Attacking", false);  //BOOL PARA ANIMACION DE ATAQUE
            attackTime = 0;
            attacking = false;
            canAttack = false;
        }

        if (player.transform.position.x <= transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            initialPositions[2] = new Vector3(353, 210, 0);
            initialPositions[3] = new Vector3(382, 148, 0);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            initialPositions[2] = new Vector3(164, 210, 0);
            initialPositions[3] = new Vector3(91, 156, 0);
        }

        /*
         Porcion de codigo encargada del ataque del jefe al player
         */

        if (canChange)  //Se cambia la posicion inicial del boss para cambiar el lugar donde esta estatico por mas tiempo
        {
            initialPosition = initialPositions[Random.Range(1, 4)];
            canChange = false;
        }

        Vector3 target = initialPosition;

        attackWait += Time.deltaTime;

        if ((attackWait >= 3f) && (canAttack) && (!specialAttack))
        {
            walking = true;
            target = player.transform.position;
        }

        if (cont >= 2)  //Cada numero de ataques o regreso a su sitio inicial, se hara un ataque especial
        {
            specialAttack = true;
            missile[0].ResetPosition();
            missile[1].ResetPosition();
            missile[2].ResetPosition();
            missile[3].ResetPosition();
            missile[4].ResetPosition();
            cont = 0;
            fireballSound = true;
        }

        float distance = Vector3.Distance(target, transform.position);

        if (specialAttack)
        {
            Invoke("playFireballSound", 0.6f);
            canChange = false;
            initialPosition = specialAttackPosition;
            target = initialPosition;
            specialAttackTime += Time.deltaTime;
            if (distance < 2f)  //Validacion para que al estar muy cerca de la posicion se coloque en ella y no se quede en un bucle intentando llegar
            {
                transform.position = initialPosition;
                canAttack = true;
                walking = false;
            }
            SpecialAttack();
        }

        if (attackWait >= 10f)
        {
            attackWait = 0;
            canChange = true;
            cont += 1;
        }

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);

        Debug.DrawRay(transform.position, forward, Color.red);

        Vector3 dir = (target - transform.position).normalized;

        if ((target != initialPosition && distance < attackkRadius) || attacking)
        {
            //Atacar detenido
        }
        else
        {
            if (dir.x > 0)  //Validacion para que la animacion vaya con respecto a la direccion
            {
                if (walking) 
                {
                    GetComponent<SpriteRenderer>().flipX = true; 
                }
            }
            else
            {
                if (walking)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            //Movimiento hacia el objetivo
            GetComponent<Rigidbody2D>().MovePosition(transform.position + dir * speed * Time.deltaTime);
        }

        if (target == initialPosition && distance < 2f)  //Validacion para que al estar muy cerca de su posicion inicial retorne a ella y no se quede en un bucle intentando llegar
        {
            transform.position = initialPosition;
            canAttack = true;
            walking = false;
        }

        Debug.DrawLine(transform.position, target, Color.green);
    }

    public override void Attack(Entity player)
    {
        attacking = true;
        GetComponent<Animator>().SetBool("Attacking", true);
        if (attackTime >= 0.5f)    //Tiempo que tarda en hacer daño
        {
            attackTime = 0;
            if ((player.GetStatValue(Stat.Health) > 0) && (GetStatValue(Stat.Health) > 0))
            {
                player.TakeDamage(GetStatValue(Stat.Strength));
                SoundController.assignSound(laugh);
                SoundController.playSound();
            }
            canAttack = false;
            canChange = true;
            attackWait = 0;
            cont += 1;
        }

    }

    void SpecialAttack()
    {
        if (canAttack && transform.position == specialAttackPosition)
        {
            attacking = true;
            missile[0].gameObject.SetActive(true);
            missile[1].gameObject.SetActive(true);
            missile[2].gameObject.SetActive(true);
            missile[3].gameObject.SetActive(true);
            missile[4].gameObject.SetActive(true);
            if (specialAttackTime >= 3f)   //Pasado el tiempo de ataque especial, esto pasara
            {
                specialAttack = false;
                attacking = false;
                canChange = true;
                attackWait = 2f;
                missile[0].gameObject.SetActive(false);
                missile[1].gameObject.SetActive(false);
                missile[2].gameObject.SetActive(false);
                missile[3].gameObject.SetActive(false);
                missile[4].gameObject.SetActive(false);
                specialAttackTime = 0;
            }
        }
    }

    private void playFireballSound(){
        if (fireballSound){
                SoundController.playOneShot(fireball);
                fireballSound = false;
            }
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
             *
             *canAttack = false;
             *GetComponent<Animator>().SetBool("Attacking", canAttack);
             */
            player.Attack(this);
            enemyHealth.setHealth(health);
        }
        else if ((collision.transform.tag == "Player") && player.isPlayerAlive())
        {
            if ((attackWait >= 3) && canAttack)
            {
                Attack(player);
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.transform.tag == "Player") && player.isPlayerAlive())
        {
            if ((attackWait >= 3) && canAttack)
            {
                Attack(player);
                SoundController.playOneShot(firebreath);
            }
        }
    }

}
