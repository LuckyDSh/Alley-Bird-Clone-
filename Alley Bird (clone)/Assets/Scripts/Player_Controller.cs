/*
*	TickLuck
*	All rights reserved
*/
using BayatGames.SaveGameFree;
using System.Collections;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    [Header("Parameters")]
    [SerializeField] private float jump_force_on_death = 100f;
    [SerializeField] private float jump_force = 150f;
    [SerializeField] private GameObject GO_Menu;

    public static int SCORE_NUM = 0;
    private CameraFollow script_to_diactivate_on_death;
    private bool is_grounded = true;
    private bool is_on_second_jump = false;
    private readonly float TIME_TO_DELAY_DEATH = 2f;
    private Collider2D player_collider;
    private Rigidbody2D player_RB;
    #endregion

    #region UnityMethods
    void Start()
    {
        SCORE_NUM = 0;
        script_to_diactivate_on_death = Camera.main.GetComponent<CameraFollow>();
        player_collider = GetComponent<Collider2D>();
        player_RB = GetComponent<Rigidbody2D>();
        is_grounded = true;
        is_on_second_jump = false;
    }
    #endregion

    #region JUMP
    public void Jump()
    {
        if (is_grounded)
        {
            player_RB.AddForce(player_RB.transform.up * jump_force, ForceMode2D.Impulse);
            is_grounded = false;
            is_on_second_jump = true;
            return;
        }
        if (is_on_second_jump)
        {
            player_RB.AddForce(player_RB.transform.up * jump_force, ForceMode2D.Impulse);
            is_on_second_jump = false;
            return;
        }
        //else
        //{
        //    is_grounded = true;
        //    return;
        //}
    }
    #endregion

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Cat")
            StartCoroutine("Die");
        if (collision.collider.tag == "PLATFORM")
            is_grounded = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ENDZONE"))
            MENU_CONTROLLER.GAME_WIN();
    }

    #region DEATH
    private IEnumerator Die()
    {
        player_RB.constraints = RigidbodyConstraints2D.FreezePositionX;
        script_to_diactivate_on_death.enabled = false;
        player_collider.enabled = false;
        player_RB.AddForce(player_RB.transform.up * jump_force_on_death, ForceMode2D.Impulse);
        GO_Menu.SetActive(true);

        yield return new WaitForSeconds(TIME_TO_DELAY_DEATH);
        SaveGame.Save("SCORE", Player_Controller.SCORE_NUM);

        Destroy(gameObject);
    }
    #endregion
}
