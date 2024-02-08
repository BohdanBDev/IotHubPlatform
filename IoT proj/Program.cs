internal class Program
{
    private static void Main(string[] args)
    {
        List<IrlComponent> listBlackBoxes = new List<IrlComponent>();
        BuilderComponent builder = new BuilderComponent();
        IrlEvents irlData = new IrlEvents();
        IrlEvents passData = new IrlEvents();

        builder.BuildIotLocator();
        builder.BuildIotTermometr();

        listBlackBoxes.Add(builder.GetComponent());
        
        builder.BuildIotLocator();
        builder.BuildIotShockIndicator();

        listBlackBoxes.Add(builder.GetComponent());
        
        builder.BuildIotLocator();
        builder.BuildIotTermometr();
        builder.BuildIotShockIndicator();

        listBlackBoxes.Add(builder.GetComponent());

        for(int i = 0; i < listBlackBoxes.Count(); i++)
        {
            irlData.onNewData += listBlackBoxes[i].UpdateData;
            passData.onNewData += listBlackBoxes[i].ShowData;
        }

        for(int i = 0; i < 10; i++)
        {
            foreach(var box in listBlackBoxes)
            {
                irlData.Costile(); // imitation of affect on components
            }
            
            passData.Costile(); // imitation of passing data
            Thread.Sleep(5000);
        }
    }
}