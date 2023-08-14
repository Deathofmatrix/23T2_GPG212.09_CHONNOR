public class StateFactory
{
    StateMachine context;

    public StateFactory(StateMachine currentContext)
    {
        context = currentContext;
    }



    public AppleShop AppleShopState()
    {
        return new AppleShop(context, this);
    }

    public CarrotShop CarrotShopState()
    { 
        return new CarrotShop(context, this); 
    }

    public NoShop NoShopState()
    {
        return new NoShop(context,this);
    }
}
