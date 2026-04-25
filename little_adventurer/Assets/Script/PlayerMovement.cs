using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerspeed = 3.5f;
    public float playergravity = -9.81f;
    private CharacterController controller;
    private Animator anim;
    Vector3 move;
    private Vector3 velocity;
    public float attackRange = 2f;
    public int attackDamage = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");

            if(AudioManager.instance != null)
                AudioManager.instance.PlaySwordSound();
            
            AttackEnemy();
        }

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            move = transform.right * x + transform.forward * z;
            controller.Move(move * playerspeed * Time.deltaTime);

            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += playergravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            anim.SetFloat("MoveX", x);
            anim.SetFloat("MoveZ", z);
    }

    void AttackEnemy()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange);
        foreach(Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                break;
            }
        }
    }
    
}
