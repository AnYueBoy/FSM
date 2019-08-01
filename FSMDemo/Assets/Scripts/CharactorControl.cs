/**
 * 创建者：栾浩元
 * 描述：人物控制
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorControl : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public Animator myAnimator;

    [Header("移动速度")]
    public float moveSpeed = 0;

    [Header("跳跃力")]
    public float jumpForce = 0;

    [Header("碰撞层")]
    public LayerMask layerMask;

    private void Start()
    {

    }

    private void Update()
    {
        this.Move();

        this.Jump();

        this.Attack();
    }

    private void Move()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        float horizontalValue = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalValue) == 0)
        {
            this.myAnimator.SetBool("isRun", false);
            return;
        }
        horizontalValue = horizontalValue > 0 ? 1 : -1;
        this.myAnimator.SetBool("isRun", true);
        // 对刚体同时施加两个速度，会让跳跃异常
        transform.Translate(new Vector2(horizontalValue * moveSpeed * Time.deltaTime, 0));
        this.transform.localScale = new Vector3(-horizontalValue, 1, 1);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                return;
            }

            if (!this.IsGround())
            {
                return;
            }
            this.myAnimator.Play("Jump");

            this.myRigidbody.velocity = new Vector2(0, 0);

            this.myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                return;
            }

            this.myAnimator.Play("Attack");
        }
    }

    private bool IsGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f, layerMask))
        {
            return true;
        }
        return false;
    }
}