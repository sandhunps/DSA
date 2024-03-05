public class Datetime_Revision
{
    public void Working_with_Datetime()
    {
        // - DateTime is a type which is internally a structure
        // - DateTime is immutable.

        var time = new DateTime(2041, 01, 01);

        var now = DateTime.Now;

        var today = DateTime.Today;

        Console.WriteLine("Time : {0}", time);
        Console.WriteLine("Now : {0}", now);
        Console.WriteLine("Today : {0}", today);

        Console.WriteLine("Methods on Datetime object..");

        Console.WriteLine("Hour :" + now.Hour);
        Console.WriteLine("Minute :" + now.Minute);

        var tomorrow =  now.AddDays(1);
        var yesterday =  now.AddDays(-1);

        Console.WriteLine("Tomorrow : ", tomorrow);
        Console.WriteLine("Yesterday :", yesterday);

        // Converting Datetime to string
        Console.WriteLine("Long Date String : {0}",now.ToLongDateString());
        Console.WriteLine("Short Date String : {0}",now.ToShortDateString());
        Console.WriteLine("Long Time String: {0},",now.ToLongTimeString());
        Console.WriteLine("Short Time String: {0}",now.ToShortDateString());
        
        Console.WriteLine(now.ToString("dd-MM-yyyy"));
    }

    public void Working_with_Timespan()
    {
        // In C# Timespan is a struct that represents a time interval.
        // Provides a convinebt way to work with duration ot time differneces
        // Timespan is Immutable

        // Creating 
        var timespan = new TimeSpan(1,2,3);
        
        var timespan1 =  new TimeSpan(1, 0, 0);
        var timespan2 = TimeSpan.FromHours(1);

        var start =  DateTime.Now;
        var end  =  DateTime.Now.AddMinutes(10);
        var duration = end-start;
        Console.WriteLine("Duration : {0}", duration);

        // Properties 
        Console.WriteLine("Minutes :{0}",timespan.Minutes);
        Console.WriteLine("TotalMinutes : {0}", timespan.TotalMinutes);

        // Methods 
        Console.WriteLine("Add : {0}",timespan.Add(TimeSpan.FromMinutes(6)));
        Console.WriteLine("Subtract :{0}",timespan.Subtract(TimeSpan.FromMinutes(20)));

        // To String
        Console.WriteLine("To Srtring :{0}", timespan.ToString());

        // Parse
        Console.WriteLine("Parse : {0}", TimeSpan.Parse("01:10:03"));
    }
}
