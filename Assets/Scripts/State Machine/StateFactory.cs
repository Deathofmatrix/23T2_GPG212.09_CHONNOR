public class StateFactory
{
    StateMachine context;

    public StateFactory(StateMachine currentContext)
    {
        context = currentContext;
    }


    public ShopState Shop()
    {
        return new ShopState(context, this);
    }
  
    public NoShop NoShopState()
    {
        return new NoShop(context,this);
    }
}
