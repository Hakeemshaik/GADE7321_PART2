using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject player1Cursor;
    public GameObject player2Cursor;
    public Canvas canvas;
    public Button[] allButtons;
    public Text player1IngredientsText;
    public Text player2IngredientsText;

    private bool player1Selected;
    private bool player2Selected;

    void Start()
    {
        
        // Ensure cursors are initially inactive
        player1Cursor.SetActive(false);
        player2Cursor.SetActive(false);

        // Activate cursor for the first player
        player1Cursor.SetActive(true);

        // Set cursor positions to match initial mouse position
        Vector3 initialMousePosition = Input.mousePosition;
        player1Cursor.transform.position = initialMousePosition;
        player2Cursor.transform.position = initialMousePosition;
    }

    void AssignIngredients()
    {
        // Define ingredient names
        string[] ingredientNames = { "Strawberry", "Kale", "Mango", "Banana", "Toothpaste", "Tomato", "Blueberries", "Cheese", "Pineapple", "Spinach" };

        // Assign each ingredient to its respective button
        for (int i = 0; i < allButtons.Length; i++)
        {
            Button button = allButtons[i];
            string ingredientName = ingredientNames[i];

            // Set button text according to ingredient
            button.GetComponentInChildren<Text>().text = ingredientName;

            // Add listener for button click
            button.onClick.AddListener(() => OnIngredientButtonClick(button));
        }
    }

    void Update()
    {
        // Check for player input
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast to detect button clicks
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is a button
                Button button = hit.collider.GetComponent<Button>();
                if (button != null)
                {
                    // Perform button click
                    button.onClick.Invoke();
                }
            }
        }
    }

    void SwitchPlayerCursors()
    {
        // Toggle player cursors
        player1Cursor.SetActive(!player1Cursor.activeSelf);
        player2Cursor.SetActive(!player2Cursor.activeSelf);
    }

    public void OnIngredientButtonClick(Button button)
    {
        // Get ingredient name from button
        string ingredientName = button.GetComponentInChildren<Text>().text;

        // Update player ingredients text based on cursor active state
        if (player1Cursor.activeSelf)
        {
            player1IngredientsText.text += ingredientName + "\n";
            player1Selected = true;
        }
        else if (player2Cursor.activeSelf)
        {
            player2IngredientsText.text += ingredientName + "\n";
            player2Selected = true;
        }

        // Deactivate button
        button.interactable = false;

        // Check if both players have selected ingredients
        if (player1Selected && player2Selected)
        {
            // Perform actions for both players having selected ingredients
            // For example: Switch to the next phase of the game
            Debug.Log("Both players have selected ingredients.");
        }

        // Switch player cursors
        SwitchPlayerCursors();
    }
}