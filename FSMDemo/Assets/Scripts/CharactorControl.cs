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

    private void Start()
    {

    }

    private void Update()
    {
        this.Move();

        this.Jump();
    }

    private void Move()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalValue) == 0)
        {
            this.myAnimator.SetBool("isRun", false);
            return;
        }
        horizontalValue = horizontalValue > 0 ? 1 : -1;
        this.myAnimator.SetBool("isRun", true);
        // 对刚体同时施加两个速度，会让跳跃异常
        transform.Translate(new Vector2(horizontalValue*moveSpeed*Time.deltaTime,0));
        this.transform.localScale = new Vector3(-horizontalValue, 1, 1);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           this.myAnimator.Play("Jump");

            this.myRigidbody.velocity = new Vector2(0, 0);


            this.myRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}