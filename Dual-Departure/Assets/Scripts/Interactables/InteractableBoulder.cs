using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableBoulder : MonoBehaviour, IInteractable
{
    public float interactForce = 2000;
    public GameObject textObject;
    public TextMeshPro text;
    public bool isHighlighted;
    public void Interact(GameObject player)
    {
        // Apply foce from the direction of the player
        Debug.Log("Interacted");
        this.GetComponent<Rigidbody>().AddForce(player.transform.forward.normalized * interactForce);
    }

    public void Highlight(GameObject player)
    {
        if (textObject == null)
        {
            textObject = new GameObject();
            text = textObject.gameObject.AddComponent<TextMeshPro>();
            textObject.gameObject.transform.position = this.gameObject.transform.position;
            text.text = "E";
            text.color = Color.red;
            text.fontSize = 10;
            text.alignment = TextAlignmentOptions.Center;
        }
        isHighlighted = true;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textObject != null && isHighlighted)
        {
            textObject.SetActive(isHighlighted);
            textObject.transform.position = this.gameObject.transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
