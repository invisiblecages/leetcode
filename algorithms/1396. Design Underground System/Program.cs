/*
An underground railway system is keeping track of customer travel times between different stations. 
They are using this data to calculate the average time it takes to travel from one station to another.

Implement the UndergroundSystem class:

    void checkIn(int id, string stationName, int t)
        A customer with a card ID equal to id, checks in at the station stationName at time t.
        A customer can only be checked into one place at a time.
    void checkOut(int id, string stationName, int t)
        A customer with a card ID equal to id, checks out from the station stationName at time t.
    double getAverageTime(string startStation, string endStation)
        Returns the average time it takes to travel from startStation to endStation.
        The average time is computed from all the previous traveling times from startStation to endStation that happened directly, 
		meaning a check in at startStation followed by a check out from endStation.
        The time it takes to travel from startStation to endStation may be different from the time it takes to travel from 
		endStation to startStation.
        There will be at least one customer that has traveled from startStation to endStation before getAverageTime is called.

You may assume all calls to the checkIn and checkOut methods are consistent. 
If a customer checks in at time t1 then checks out at time t2, then t1 < t2. All events happen in chronological order.

Constraints:

    1 <= id, t <= 106
    1 <= stationName.length, startStation.length, endStation.length <= 10
    All strings consist of uppercase and lowercase English letters and digits.
    There will be at most 2 * 104 calls in total to checkIn, checkOut, and getAverageTime.
    Answers within 10-5 of the actual value will be accepted.
*/
// TODO: Refactor this
// Time complexity: O(?)
// Space complexity: O(?)
public class UndergroundSystem 
{
  private Dictionary<int, (string, int)> checkIns;
  private Dictionary<(string, string), (int, int)> travels;

  public UndergroundSystem() 
  {
    checkIns = new();
    travels = new();
  }
  
  public void CheckIn(int id, string stationName, int t) 
  {
    checkIns[id] = (stationName, t);
  }
  
  public void CheckOut(int id, string stationName, int t) 
  {
    if (checkIns.TryGetValue(id, out var checkInsValue))
    {
      string station = checkInsValue.Item1;
      int time = checkInsValue.Item2;
      var key = (station, stationName);

      if (travels.ContainsKey(key))
      {
        var value = travels[key];
        travels[key] = (value.Item1 + (t - time), value.Item2 + 1);
      }
      else
        travels[key] = (t - time, 1);

      checkIns.Remove(id);
    }
  }
  
  public double GetAverageTime(string startStation, string endStation) 
  {
    if (travels.TryGetValue((startStation, endStation), out var travelsValue))
    {
      int totalTime = travelsValue.Item1;
      int count = travelsValue.Item2;
      
      return totalTime / (double)count;
    }
    else
      return 0;  
  }
}
/**
 * Your UndergroundSystem object will be instantiated and called as such:
 * UndergroundSystem obj = new UndergroundSystem();
 * obj.CheckIn(id,stationName,t);
 * obj.CheckOut(id,stationName,t);
 * double param_3 = obj.GetAverageTime(startStation,endStation);
 */