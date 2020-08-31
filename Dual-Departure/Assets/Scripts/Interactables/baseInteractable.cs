using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class baseInteractable : MonoBehaviour
{

    //  public abstract void Interact(GameObject player);
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

    public virtual void Highlight(PlayerController player)
    {
        Debug.Log("Hihglighting");
        isHighlighted = true;
        if (textObject == null)
        {
            Debug.Log("Creating text object");
            // Create a text above the interactable that shows the interact-key
            textObject = new GameObject();
            text = textObject.gameObject.AddComponent<TextMeshPro>();
          
       
            text.color = Color.red;
            text.fontSize = 10;
            text.alignment = TextAlignmentOptions.Center;

            // textObject.gameObject.transform.position = this.gameObject.transform.position;
        }
        // Set the actual textelement
        if (player.tag == "Human")
        {
            Debug.Log("Human Highlight");
            text.text = "E"; // TODO: Replace this with actual button for current player. Check input manager for runtime values
        }
        else
        {
            Debug.Log("Robot Highlight");
            text.text = "O"; // TODO: Replace this with actual button for current player. 
        }
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
