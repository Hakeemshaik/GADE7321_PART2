using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID; // Unique identifier for each player
    public List<int> selectedIngredients; // List to hold selected ingredient numbers
    public List<string> smoothie; // List to hold ingredients in the smoothie

    // Dictionary to map ingredient numbers to their names
    private Dictionary<int, string> ingredientMap = new Dictionary<int, string>()
    {
        {1, "Strawberry"},
        {2, "Banana"},
        {3, "Spinach"},
        // Add more mappings for other ingredients as needed
    };

    // Method to add an ingredient to the smoothie
    public void AddIngredient(int ingredientNumber)
    {
        // Check if the player has already selected the maximum number of ingredients
        if (selectedIngredients.Count < maxIngredientSelection)
        {
            // Add the ingredient number to the list of selected ingredients
            selectedIngredients.Add(ingredientNumber);

            // Convert the ingredient number to its corresponding ingredient name and add it to the smoothie
            smoothie.Add(ingredientMap[ingredientNumber]);
        }
        else
        {
            Debug.LogWarning("Maximum number of ingredients selected. Cannot add more.");
        }
    }

    // Maximum number of ingredients a player can select
    private const int maxIngredientSelection = 3; // Change this value to your desired maximum number of ingredients
}