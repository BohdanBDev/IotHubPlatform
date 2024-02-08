public class IotTermometr : IotComponent
{
    public IotTermometr()
    {
        this.mainValue = 0;
        this.isOn = false;
    }

    public object? _MainValue;

    public override object mainValue //GeoPoint
    {
        get
        {
            if (_MainValue == null)
                throw new NullReferenceException("temperature is null");
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