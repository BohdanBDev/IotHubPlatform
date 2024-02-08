public class IotShockIndicator : IotComponent
{
    public IotShockIndicator()
    {
        this.mainValue = 0;
        this.isOn = false;
    }

    private object? _MainValue;

    public override object mainValue //GeoPoint
    {
        get
        {
            if (_MainValue == null)
                throw new NullReferenceException("shock indicator is null");
            else
                return _MainValue;
        } 

        set
        {
            if (value == null)
                throw new NullReferenceException("value is null");
            else
                _MainValue = value;
        }
    }
}