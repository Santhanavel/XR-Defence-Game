using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public enum EnemyAnimType
    {
        Idle,
        Walk01,
        Walk02,
        Attack01,
        Attack02,
        Hit01,
        Hit02,
        Dead01,
        Dead02
    }

    [SerializeField] private Animator anim;
    [SerializeField] private EnemyAnimType currentAnim = EnemyAnimType.Idle;


    public void Play(EnemyAnimType type)
    {
        // Avoid replaying same animation repeatedly
        if (currentAnim == type)
            return;

        currentAnim = type;
        anim.Play(type.ToString());   // Animation state must match enum name
    }

    public bool IsPlaying(string animName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    public bool IsFinished()
    {
        var info = anim.GetCurrentAnimatorStateInfo(0);
        return info.normalizedTime >= 1f;
    }
}

