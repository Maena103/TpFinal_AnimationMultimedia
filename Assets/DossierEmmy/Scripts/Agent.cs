using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] private GameObject _joueur;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _attackAudioSource;
    [SerializeField] private float _attackRange = 2.0f;

    private LevelManager _levelManager;
    private Vector3 _positionJoueur;
    private bool _isAttacking = false;

    void Start()
    {
        _levelManager = LevelManager.Instance;
    }

    void Update()
    {
        BougerAgent();
        CheckAttack();
    }

    void BougerAgent()
    {
        if (!_isAttacking)
        {
            _positionJoueur = _joueur.transform.position;
            _agent.SetDestination(_positionJoueur);
        }
    }

    void CheckAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _joueur.transform.position);
        if (distanceToPlayer <= _attackRange)
        {
            if (!_isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
    }

    private IEnumerator AttackPlayer()
    {
        _isAttacking = true;
        _agent.isStopped = true;

        // Jouer l'animation d'attaque
        _animator.SetTrigger("Attack");

        // Jouer le son d'attaque
        _attackAudioSource.Play();

        // Attendre la fin de l'animation d'attaque
        float attackAnimationLength = _animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(attackAnimationLength);

        // Attendre la fin du son d'attaque (si nécessaire)
        float attackSoundLength = _attackAudioSource.clip.length;
        yield return new WaitForSeconds(attackSoundLength);

        // Attendre 2 secondes supplémentaires après l'animation et le son
        yield return new WaitForSeconds(2.0f);

        // Effectuer les actions après l'attaque
        OnAttackCompleted();

        _isAttacking = false;
        _agent.isStopped = false;
    }

    private void OnAttackCompleted()
    {
        // Ici vous pouvez ajouter des actions après l'attaque, comme infliger des dégâts au joueur
        _levelManager.LoadAsyncScene(LevelManager.Scene.SceneMort);
    }


}
