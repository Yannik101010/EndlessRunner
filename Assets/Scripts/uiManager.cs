using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    //coin Text
    public static int coins = 0;
    [SerializeField]
    private Text coin_Text;
    //destroyed text
    public static bool destroyed = false;
    [SerializeField]
    private Text destroyed_Text;
    //Shield equipped Text
    public static bool shield = false;
    [SerializeField]
    private Text shield_Text;

    //coins is shown at the start
    void Start()
    {
        coin_Text.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        //coins is checked in the update and increases if coins are collcted
        coin_Text.text = "Coins: " + coins;
        //destroyed is true if shield is not equipped and player collides with obstacle (see player script)
        if (destroyed)
        {
            destroyed_Text.text = "Game Over";
        }
        //is shown if shield is equipped 
        if (player.shield == 1)
        {
            shield_Text.text = "Shield equipped!";
        }
        //nothing is shown if no shield is equipped
        else
        {
            shield_Text.text = " ";
        }
    }
}