

public class IotLocator : IotComponent
{
    public IotLocator()
    {
        this.mainValue = new GeoPoint(0, 0);
        this.isOn = false;
        
    }

    private object? _MainValue;

    public override object mainValue //GeoPoint
    {
        get
        {
            if (_MainValue == null)
                throw new NullReferenceException("geo position is null");
            else
                return (GeoPoint)_MainValue;
        } 

        set
        {
            if (value == null)
                throw new NullReferenceException("value geo position is null");
            else 
                _MainValue = value;
        }
    }
}