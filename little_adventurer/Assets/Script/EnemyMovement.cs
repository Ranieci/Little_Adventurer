using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float enemyspeed = 3f;
    public float enemystoppingDistance = 1.5f;
    public float enemyattackRange = 3f;
    public float enemyattackCooldown = 1.5f;
    public int enemyDamage = 10;
    private float lastAttackTime;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;
        if (player == null) return;

        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.position;

        enemyPos.y = 0;
        playerPos.y = 0;

        float distance = Vector3.Distance(transform.position, player.position);
        Vector3 lookPos = player.position;
        lookPos.y = transform.position.y;
        transform.LookAt(lookPos);
        
        if(distance > enemyattackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * enemyspeed * Time.deltaTime;
            
            if (anim != null)
                anim.SetBool("IsWalking", true);
        }        
            else
            {
                if (anim != null)
                    anim.SetBool("IsWalking", false);
                if (Time.time >= lastAttackTime + enemyattackCooldown)
                {
                    AttackPlayer(distance);
                    lastAttackTime = Time.time;
                }
                
            }
    }
    

    void AttackPlayer(float distance)
    {
        if (anim != null)
        {
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("Attack");
        }

        PlayerHealth playerHealth = player.GetComponentInChildren<PlayerHealth>();

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(enemyDamage);
        }
    }
}
