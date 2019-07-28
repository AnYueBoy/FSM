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

    private void Start()
    {

    }

    private void Update()
    {
        this.Move();
    }

    private void Move()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        if (horizontalValue == 0)
        { 
            this.myAnimator.Play("Idel");
            return;
        }
        horizontalValue = horizontalValue > 0 ? 1 : -1;
        this.myAnimator.Play("Run");
        this.myRigidbody.velocity = new Vector2(horizontalValue * moveSpeed, 0);
        this.transform.localScale = new Vector3(-horizontalValue, 1, 1);

    }
}