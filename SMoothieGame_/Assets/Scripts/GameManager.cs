using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject player1Cursor;
    public GameObject player2Cursor;
    private int currentPlayer = 1;
    public Button[] allButtons;
    public Text player1TextBox;
    public Text player2TextBox;
    public Text player1IngredientsText;
    public Text player2IngredientsText;
    private List<string> allIngredients = new List<string> { "Strawberries", "Bananas", "Blueberries", "Mango", "Pineapple", "Kale", "Tomato", "ToothPaste", "Cheese", "Spinach" };
    private Dictionary<Button, string> buttonIngredientMap = new Dictionary<Button, string>();
    private List<string> player1IngredientsList = new List<string>();
    private List<string> player2IngredientsList = new List<string>();
    private bool player1Selected;
    private bool player2Selected;
    private bool timerRunning;

    void Start()
    {
        // Shuffle the list of ingredients
        List<string> shuffledIngredients = allIngredients.OrderBy(x => Random.value).ToList();

        // Assign ingredients to buttons
        AssignIngredients(allButtons, shuffledIngredients);

        player1Cursor.SetActive(true);
        player2Cursor.SetActive(false);
        StartCoroutine(PlayerTimer());
    }

    void AssignIngredients(Button[] playerButtons, List<string> ingredients)
    {
        foreach (Button button in playerButtons)
        {
            // Assign an ingredient to the button
            string ingredient = ingredients[0];
            ingredients.RemoveAt(0);
            buttonIngredientMap.Add(button, ingredient);

            button.onClick.AddListener(delegate { OnIngredientButtonClick(button); });
        }
    }

    IEnumerator PlayerTimer()
    {
        timerRunning = true;
        yield return new WaitForSeconds(10f);
        if (currentPlayer == 1 && !player1Selected)
        {
            SelectRandomIngredient(allButtons);
        }
        else if (currentPlayer == 2 && !player2Selected)
        {
            SelectRandomIngredient(allButtons);
        }
        timerRunning = false;
    }

    void SelectRandomIngredient(Button[] playerButtons)
    {
        foreach (Button button in playerButtons)
        {
            if (button.interactable)
            {
                OnIngredientButtonClick(button);
                break;
            }
        }
    }

    void OnIngredientButtonClick(Button button)
    {
        string ingredientName = buttonIngredientMap[button];
        button.interactable = false;

        if (currentPlayer == 1)
        {
            player1Selected = true;
            player1IngredientsList.Add(ingredientName);
            player1IngredientsText.text = "Player 1 Ingredients:\n" + string.Join("\n", player1IngredientsList.ToArray());
        }
        else
        {
            player2Selected = true;
            player2IngredientsList.Add(ingredientName);
            player2IngredientsText.text = "Player 2 Ingredients:\n" + string.Join("\n", player2IngredientsList.ToArray());
        }

        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        player1Cursor.SetActive(currentPlayer == 1);
        player2Cursor.SetActive(currentPlayer == 2);

        if (!timerRunning)
        {
            StartCoroutine(PlayerTimer());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            player1Cursor.SetActive(currentPlayer == 1);
            player2Cursor.SetActive(currentPlayer == 2);
        }
    }
}