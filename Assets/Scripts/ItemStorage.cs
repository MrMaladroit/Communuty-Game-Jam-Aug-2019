using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    [SerializeField] Desires[] items;
    [SerializeField] GameObject menu;
    private bool playerCanInteract;
    private Inventory playerInventory;
    private Dictionary<string, Desires> dict = new Dictionary<string, Desires>();

    private void Awake()
    {
        PlayerInput.InteractButtonPressed += HandleInteraction;
        foreach (Desires item in items)
        {
            dict.Add(item.ToString(), item);
        }
    }

    private void OnDisable()
    {
        PlayerInput.InteractButtonPressed -= HandleInteraction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
        // Set some kind of variable to true to listen for interact button press
        playerCanInteract = true;
        playerInventory = collision.GetComponentInParent<Inventory>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exited");
        // Set some kind of variable to false so the interact button doesn't trigger anything
        playerCanInteract = false;
        menu.SetActive(false);
        playerInventory = null;
    }

    private void HandleInteraction()
    {
        if (playerCanInteract)
        {
            menu.SetActive(true);
        }
    }
    public void SelectItem(string itemString)
    {
        Desires desire;
        if(dict.TryGetValue(itemString, out desire))
        {
            Debug.Log(desire.ToString());
            playerInventory.AddItem(desire);
        }
        else
        {
            Debug.Log("Key not in Dictionary");
        }

        menu.SetActive(false);
    }
}