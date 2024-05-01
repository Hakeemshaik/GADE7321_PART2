using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    void Start()
    {
        // Hide the cursor GameObject
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the position of the mouse pointer in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Set the z-coordinate to ensure the cursor is at the same depth as the GameObjects in the scene
        mousePosition.z = 10f;

        // Convert screen coordinates to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Set the position of the cursor GameObject to the calculated world position
        transform.position = worldPosition;
    }
}

