namespace Elons_Cars;


/* In this exercise you'll be playing around with a remote controlled car, which you've finally saved enough money for to buy.

Cars start with full (100%) batteries. Each time you drive the car using the remote control, it covers 20 meters and drains one percent of the battery.

The remote controlled car has a fancy LED display that shows two bits of information:

    The total distance it has driven, displayed as: "Driven <METERS> meters".
    The remaining battery charge, displayed as: "Battery at <PERCENTAGE>%".

If the battery is at 0%, you can't drive the car anymore and the battery display will show "Battery empty".

You have six tasks, each of which will work with remote controlled car instances.
*/

class RemoteControlCar
{
    private double _distanceDriven;
    private int _batteryPercentage;

    public RemoteControlCar()
    {
        _distanceDriven = 0;
        _batteryPercentage = 100;
    }
    
    public static RemoteControlCar Buy()
    {
        // Implement the (static) RemoteControlCar.Buy() method to return a brand-new remote controlled car instance:
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        // Implement the RemoteControlCar.DistanceDisplay() method to return the distance as displayed on the LED display:
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        // Implement the RemoteControlCar.BatteryDisplay() method to return the battery percentage as displayed on the LED display:
        return _batteryPercentage > 0 ? $"Battery at {_batteryPercentage}%" : "Battery empty";
    }

    public void Drive()
    {
        // Update the RemoteControlCar.Drive() method to not increase the distance driven nor decrease the battery percentage when the battery is drained (at 0%):
        if (_batteryPercentage == 0)
        {
            System.Threading.Thread.Sleep(10);
        }
        else
        {
            // Implement the RemoteControlCar.Drive() method that updates the number of meters driven:
            _distanceDriven += 20;
        
            // Update the RemoteControlCar.Drive() method to update the battery percentage:
            _batteryPercentage -= 1;
        }
    }
}