using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour
{
    // Ran a quick test - This does need to be on the player charcter for the full functionanility
    // I tried having it on a seperate State Machine Manager, but it never moved into the UpdateState function 
    // I don't know why, but wee're on bnorrowed time, so i'm moving on

    BaseState currentState;
    StateFactory states;


    public TextMeshProUGUI pressE;
    public static bool isInShop = false;
    public GameObject shopPanel;

    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }


     
    public TextMeshProUGUI PressE { get { return pressE; } set { pressE = value; } }
    public bool IsInShop { get { return isInShop; } set { isInShop = value; } }
    public GameObject ShopPanel { get { return shopPanel; } set { shopPanel = value; } }


    private void Awake()
    { 
        states = new StateFactory(this);
        currentState = states.NoShopState();
        currentState.EnterState();
    }

 
    void Update()
    {

        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider collider)
    {
        currentState.OnTriggerEnter(this, collider);
    }

    private void OnTriggerExit(Collider collider)
    {
        currentState.OnTriggerExit(this, collider);
    }
}
