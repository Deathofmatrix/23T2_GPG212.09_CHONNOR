using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    StateFactory states;

    public BaseState CurrentState { get { return currentState; } set { currentState = value; } }


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
