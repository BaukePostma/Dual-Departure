using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// base abstract class for all objects that can be interacted with by one of the players. Uses a strategy-pattern to determine behavior
/// </summary>
public abstract class baseInteractable : MonoBehaviour
{

    public abstract void Interact(PlayerController player);

    private GameObject textObject;
    private TextMeshPro text;
    [HideInInspector]
    public bool isHighlighted;

    // Update is called once per frame
    public  void FixedUpdate()
    {
        isHighlighted = false;
    }

    void LateUpdate()
    {
        DisplayText();
    }

    /// <summary>
    /// If the player can interact with an object, highlight it
    /// </summary>
    /// <param name="The player calling the method"></param>
    public virtual void Highlight(PlayerController player)
    {
        isHighlighted = true;
        if (textObject == null)
        {
            // Create a text above the interactable that shows the interact-key
            textObject = new GameObject();
            text = textObject.gameObject.AddComponent<TextMeshPro>();
            text.color = Color.red;
            text.fontSize = 10;
            text.alignment = TextAlignmentOptions.Center;
        }
        // Set the actual textelement
        if (player.tag == "Human")
        {
            text.text = "E"; // TODO: Replace this with actual button for current player. Check input manager for runtime values
        }
        else
        {
            text.text = "O"; // TODO: Replace this with actual button for current player. 
        }

        // Position the element
        textObject.gameObject.transform.position = this.gameObject.transform.position;
        text.transform.rotation = Quaternion.LookRotation(text.transform.position - Camera.main.transform.position);
    }
    protected void DisplayText()
    {
        if (textObject != null)
        {
            textObject.SetActive(isHighlighted);
            // isHighlighted = false;
        }
        if (textObject != null && isHighlighted)
        {
            textObject.transform.position = this.gameObject.transform.position + new Vector3(0, 2f, 0);
        }

    }
}
