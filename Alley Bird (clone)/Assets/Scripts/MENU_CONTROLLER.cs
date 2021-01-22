/*
*	TickLuck
*	All rights reserved
*/
using BayatGames.SaveGameFree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU_CONTROLLER : MonoBehaviour
{
    #region Variables
    [SerializeField] private static GameObject GW_Menu;
    [SerializeField] private Text score_txt;
    private int score_buffer;
    #endregion

    #region UnityMethods
    void Start()
    {
        score_buffer = SaveGame.Load<int>("SCORE");
        GW_Menu = GameObject.FindGameObjectWithTag("GW_Menu");
    }

    void Update()
    {
        score_txt.text = Player_Controller.SCORE_NUM.ToString();
    }

    void FixedUpdate()
    {

    }
    #endregion

    public static void GAME_WIN()
    {
        GW_Menu.SetActive(true);
    }

    public void RESTART()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QUIT()
    {
        Application.Quit();
    }
}
