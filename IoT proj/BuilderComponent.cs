public class BuilderComponent
{
    private IrlComponent _component = new IrlComponent();

    public BuilderComponent()
    {
        this.Reset();
    }
    
    public void Reset()
    {
        this._component = new IrlComponent();
    }

    public void BuildIotLocator()
    {
        this._component.Add(new IotLocator());
    }

    public void BuildIotTermometr()
    {
        this._component.Add(new IotTermometr());
    }
    
    public void BuildIotShockIndicator()
    {
        this._component.Add(new IotShockIndicator());
    }

    public IrlComponent GetComponent()
    {
        IrlComponent result = this._component;

        this.Reset();

        return result;
    }
}
