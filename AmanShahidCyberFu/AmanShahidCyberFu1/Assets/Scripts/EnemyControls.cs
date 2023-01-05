using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public float speed = 5f;
    public float attackingDistance = 1f;
    private Animator anim;
    private Rigidbody rb;
    private Transform target;
    public Vector3 direction;
    public bool isFollowingTarget;
    private bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    public float currentAttackingTime;
    public float maxAttackingTime = 2f;
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update() {
        Attack();
    }

    void FixedUpdate() {
        FollowTarget();
    }

    void FollowTarget() {
        if (!isFollowingTarget) {
            rb.isKinematic = true;
            return;
        }
        if (Vector3.Distance(transform.position, target.position) >= attackingDistance) {
            rb.isKinematic = false;
            direction = target.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 100f);

            if (rb.velocity.sqrMagnitude != 0) {
                rb.velocity = transform.forward * speed;
                anim.SetBool("Walk", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= attackingDistance) {
            rb.isKinematic = false;
            rb.velocity = Vector3.zero;
            anim.SetBool("Walk", false);

            isFollowingTarget = false;
            isAttackingTarget = true;
        }
    }


    public void EnemyAttack(int attack) {
        if (attack == 0) {
            anim.SetTrigger("Attack1");
        }

        if (attack == 1) {
            anim.SetTrigger("Attack2");
        }

        if (attack == 2) {
            anim.SetTrigger("Attack3");
        }

        if (attack == 3) {
            anim.SetTrigger("Attack4");
        }

        if (attack == 4) {
            anim.SetTrigger("Attack5");
        }

        if (attack == 5) {
            anim.SetTrigger("Attack6");
        }
    }

    void Attack() {
        if (!isAttackingTarget) {
            return;
        }
        currentAttackingTime += Time.deltaTime;

        if (currentAttackingTime > maxAttackingTime) {
            EnemyAttack(Random.Range(0, 6));
            currentAttackingTime = 0f;
        }

        if (Vector3.Distance(transform.position, target.position) > attackingDistance + chasingPlayer) {
            isAttackingTarget = false;
            isFollowingTarget = true;
        }
    }
}
