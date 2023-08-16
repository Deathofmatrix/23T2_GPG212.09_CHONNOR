using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class StateMachine : MonoBehaviour
{

    // Ran a quick test - This does need to be on the player charcter for the full functionanility
    // I tried having it on a seperate State Machine Manager, but it never moved into the UpdateState function 
    // I don't know why, but wee're on bnorrowed time, so i'm moving on

    BaseState currentState;
    StateFactory states;


    public TextMeshProUGUI pressE;
    public static bool isInShop = false;
    public bool isShopOpen = false;
    public GameObject shopPanelGO;
    public GameObject upgradePanelGO;

    public NPCPurchasing currentNPC;
    public Item currentItem;
    public InventorySlot inventorySlot;

    public PlayerController actionMap;
    private InputAction interact;

    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }

    
    public TextMeshProUGUI PressE { get { return pressE; } set { pressE = value; } }
    public bool IsInShop { get { return isInShop; } set { isInShop = value; } }
    public bool IsShopOpen { get { return isShopOpen; } set { isShopOpen = value; } }
    public GameObject ShopPanelGO { get { return shopPanelGO; } set { shopPanelGO = value; } }
    public NPCPurchasing CurrentNPC { get { return currentNPC; } set { currentNPC = value; } }
    public Item CurrentItem { get { return currentItem; } set { currentItem = value; } }
    public InventorySlot InventorySlot { get { return inventorySlot; } set { inventorySlot = value; } }
    public PlayerController ActionMap { get {  return actionMap; }}


    private void Awake()
    { 
        inventorySlot = ShopPanelGO.GetComponentInChildren<InventorySlot>(); 
        states = new StateFactory(this);
        currentState = states.NoShopState();
        currentState.EnterState();
        actionMap = new PlayerController();
    }

    public void OnEnable()
    {
        ShopPanel.OnButtonPressed += CheckItemToSell;

        interact = actionMap.Player.Interact;
        interact.Enable();
        interact.performed += OpenShop;
    }

    private void OnDisable()
    {
        ShopPanel.OnButtonPressed -= CheckItemToSell;

        actionMap.Player.Interact.performed -= OpenShop;
        interact.Disable();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    public void CheckItemPrice()
    {
        currentState.CheckItemPrice();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Upgrade"))
        {
            upgradePanelGO.SetActive(true);
        }
        currentState.OnTriggerEnter(this, collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Upgrade"))
        {
            upgradePanelGO.SetActive(false);
        }
        currentState.OnTriggerExit(this, collider);
    }

    public void CheckItemToSell(Item item)
    {
        currentItem = item;
        Debug.Log("Item Is " + item);
    }
    private void OpenShop(InputAction.CallbackContext context)
    {
        Debug.Log("OpenShop");
        // Run Shop
        // Call Purchasing Method
        if (IsInShop == true)
        {
            if (!isShopOpen)
            {
                ShopPanelGO.SetActive(true);
                isShopOpen = true;
            }
            else
            {
                shopPanelGO.SetActive(false);
                isShopOpen = false;
            }
        }
    }
}
