using UnityEngine;

public class ChildController : MonoBehaviour
{
    private Desires desire;
    [SerializeField] TextPopUp bubble;
    private bool playerCanInteract = false;

    private Inventory playerInventory;
    private void Awake()
    {
        PlayerInput.InteractButtonPressed += HandleInteraction;
        SetDesire();
    }

    private void OnDisable()
    {
        PlayerInput.InteractButtonPressed -= HandleInteraction;
    }
    private void SetDesire()
    {
        int randomNumber = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Desires)).Length);
        desire = (Desires)randomNumber;
        bubble.SetBubbleText(desire.ToString());
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.M))
        {
            bubble.Reset();
            SetDesire();
            BroadcastDesire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerCanInteract = true;
        playerInventory = collision.GetComponentInParent<Inventory>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCanInteract = false;
        playerInventory = null;
    }

    private void BroadcastDesire()
    {
        string message = "I want " + desire.ToString();
        bubble.SetBubbleText(message);
        bubble.SetBubbleVisibility(true);
    }

    private void HandleInteraction()
    {
        if(playerCanInteract)
        {
            TakeItem(playerInventory.HeldItem);
        }
    }

    private void TakeItem(Desires itemReceived)
    {
        if(itemReceived == desire)
        {
            Debug.Log("I dont want " + itemReceived);
        }
        else
        {
            Debug.Log("Thank you!");
        }
        playerInventory.RemoveItem();
        SetDesire();
    }

    /*
     * Set random desire
     * broadcast desire
     * check if desire is met
     * reset
     * 
     * Create an IInteract interface
     */
}