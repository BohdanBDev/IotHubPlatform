public class IrlEvents
{
    public delegate void MethodContainer();

    public event MethodContainer? onNewData;

    public void Costile()
    {
        if(onNewData == null)
        {
            throw new NullReferenceException();
        }
        else
        {        
            onNewData();
        }
    }
}