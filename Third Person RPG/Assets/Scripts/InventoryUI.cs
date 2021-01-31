using UnityEngine;

// Put this script on canvas
public class InventoryUI : MonoBehaviour
{
    public Transform itemsSlotHolder;
    public GameObject inventoryUI;

    Inventory inventory;
    InventorySlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += updateUI;

        slots = itemsSlotHolder.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void updateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}
