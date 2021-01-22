/*
*	TickLuck
*	All rights reserved
*/
using UnityEngine;

public class Player_Mover : MonoBehaviour
{
    #region Variables
    [SerializeField] private float Move_speed = 20f;
    private Rigidbody2D this_RB;
    private Transform this_Transform;
    private bool is_on_direction_change = false;
    #endregion

    #region UnityMethods
    void Start()
    {
        this_Transform = transform;
        this_RB = GetComponent<Rigidbody2D>();
        is_on_direction_change = false;
    }

    void FixedUpdate()
    {
        if (!is_on_direction_change)
            this_Transform.Translate(this_Transform.right * Move_speed * Time.fixedDeltaTime);
        else
            this_Transform.Translate(-this_Transform.right * Move_speed * Time.fixedDeltaTime);
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "BORDER")
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (!is_on_direction_change)
            is_on_direction_change = true;
        else
            is_on_direction_change = false;
    }
}
