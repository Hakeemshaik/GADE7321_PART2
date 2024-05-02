using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButtonManager : MonoBehaviour
{
    public Button resultButton;
    private bool player1Selected;
    private bool player2Selected;

    void Start()
    {
        // Disable the result button at the start
        resultButton.gameObject.SetActive(false);
    }

    public void IngredientSelectedForPlayer(int player)
    {
        // Track ingredient selection for each player
        if (player == 1)
        {
            player1Selected = true;
        }
        else if (player == 2)
        {
            player2Selected = true;
        }

        // Check if both players have selected ingredients
        if (player1Selected && player2Selected)
        {
            // If all players have selected ingredients, enable the result button
            resultButton.gameObject.SetActive(true);
        }
    }
}
