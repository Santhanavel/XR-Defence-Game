using UnityEngine;
using UnityEngine.AI;
using static EnemyAnimationController;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    public EnemyAnimationController animPlayer;  // Custom animation system
    public Transform target;

    [Header("Movement")]
    public float moveSpeed = 2f;           // walking speed
    public float rotateSpeed = 6f;         // turning speed
    public float stopDistance = 1.5f;      // distance before stopping

    private bool isDead = false;

    void Start()
    {
        if (target == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                target = p.transform;
        }
    }

    void Update()
    {
        if (isDead || target == null)
            return;


        float distance = Vector3.Distance(transform.position, target.position);

        // --------------------------
        // MOVEMENT LOGIC
        // --------------------------
        if (distance > stopDistance)
        {
            MoveTowardTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    void MoveTowardTarget()
    {
        // Play walk animation
        animPlayer.Play(EnemyAnimType.Walk01);

        // Rotate toward target
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0f;

        Quaternion targetRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotateSpeed);

        // Move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void AttackTarget()
    {
        // Play attack animation
        animPlayer.Play(EnemyAnimType.Attack01);

    }

    public void Die()
    {
        isDead = true;
        animPlayer.Play(EnemyAnimType.Dead01);
    }
}
