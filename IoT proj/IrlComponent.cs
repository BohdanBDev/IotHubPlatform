public class IrlComponent
{
    private List<IotComponent> _components = new List<IotComponent>();
        
        public void Add(IotComponent component)
        {
            this._components.Add(component);
        }

        public void UpdateData() // imitotion of geting data from real life 
        {
            Random rd = new Random();

            foreach(var component in _components)
            {
                if(component.mainValue is GeoPoint)
                {
                    component.mainValue = new GeoPoint( rd.Next(-90, 90), rd.Next(-180, 180));
                }
                else
                {
                    component.mainValue = rd.Next(-100, 100);
                }
            }
        }

        public void ShowData() // imitation of passing data to iot hub
        {
            System.Console.WriteLine();
            
            foreach(var component in _components)
            {
                System.Console.WriteLine("type: " + component.GetType());

                if(component.mainValue is GeoPoint)
                {
                    System.Console.WriteLine("latitude is: " + ((GeoPoint)component.mainValue).latitude
                         + "longtitude: " + ((GeoPoint)component.mainValue).longtitude);
                }
                else
                {   
                    System.Console.WriteLine(component.GetType().ToString().Remove(0, 3) + component.mainValue);
                }
            }
        }
}