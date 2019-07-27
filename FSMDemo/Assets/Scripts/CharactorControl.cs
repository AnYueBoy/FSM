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

    public float moveSpeed = 0;

    private float oldHorizontalValue = 0;

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
        if (horizontalValue != this.oldHorizontalValue)
        {
            this.myRigidbody.velocity = new Vector2(horizontalValue * moveSpeed, 0);
            this.oldHorizontalValue = horizontalValue;
        }
        
    }
}