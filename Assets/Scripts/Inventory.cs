using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Desires HeldItem {  get { return heldItem;  } }
    [SerializeField] private Desires heldItem = Desires.noItem;

    public void AddItem(Desires item)
    {
        heldItem = item;
    }

    public void RemoveItem()
    {
        heldItem = Desires.noItem;
    }
}