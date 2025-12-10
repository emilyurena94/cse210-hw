public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // 1 lap = 50 meters → convert to kilometers → convert to miles
        double distanceMeters = _laps * 50;
        double distanceMiles = distanceMeters / 1000 * 0.62;
        return distanceMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
