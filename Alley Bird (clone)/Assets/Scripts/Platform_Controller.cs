/*
*	TickLuck
*	All rights reserved
*/
using System.Collections;
using UnityEngine;

public class Platform_Controller : MonoBehaviour
{
    #region Variables
    private Collider2D this_collider;
    [SerializeField] private readonly float time_delay_for_activation = 0.3f;
    #endregion

    #region UnityMethods
    void Start()
    {
        this_collider = GetComponent<Collider2D>();
        this_collider.enabled = false;
    }
    #endregion

    private IEnumerator Enable_collider()
    {
        yield return new WaitForSeconds(time_delay_for_activation);
        this_collider.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Controller.SCORE_NUM++;
            StartCoroutine("Enable_collider");
        }
    }
}
