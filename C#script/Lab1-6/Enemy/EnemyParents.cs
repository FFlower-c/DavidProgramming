using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParents : MonoBehaviour
{
    public int EnemyDamage;
    public int EnemyHealth;

    public float walkSpeed;
    public float WaitTime;
    public Transform[] posWalk;
    private Transform playerTransform;
    private int i = 0;

    private bool movingTowardsLeft = true;
    public float waitingTIme;

    public int chaseSpeed;
    public Transform FindPlayer;

    // Start is called before the first frame update
    void Start()
    {
        waitingTIme = WaitTime;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
   public void Update()
    {
        Cathchplayer();
    }

    public virtual void KillEnemy()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public  virtual void DamageTake(int damage)
    {
        EnemyHealth -= damage;
    }

    public virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, posWalk[i].position, walkSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, posWalk[i].position) < 0.1f)
        {
            if (WaitTime > 0)
            {
                WaitTime -= Time.deltaTime;
            }
            else
            {
                if (movingTowardsLeft)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingTowardsLeft = true;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingTowardsLeft = false ;
                }
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                WaitTime = waitingTIme;
            }
        }
    }
    void Cathchplayer()
    {
        if (FindPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindPlayer.position, chaseSpeed * Time.deltaTime);
        }
        if (FindPlayer == null )
        {
            Move();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindPlayer = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindPlayer = null;
        }
    }
}
