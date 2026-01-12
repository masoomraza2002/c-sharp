using System;
using System.Collections.Generic;
using System.Linq;

namespace AutonomousRobot.AI
{
    public class SensorReading
    {
        public int SensorId { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public double Confidence { get; set; }
    }

    public enum RobotAction
    {
        Stop,
        SlowDown,
        Reroute,
        Continue
    }

    public class DecisionEngine
    {
        
        public List<SensorReading> GetRecentReadings(List<SensorReading> sensorHistory, DateTime fromTime)
        {
            return sensorHistory
                   .Where(r => r.Timestamp >= fromTime)
                   .ToList();
        }

        
        public bool IsBatteryCritical(List<SensorReading> readings)
        {
            return readings
                   .Any(r => r.Type == "Battery" && r.Value < 20);
        }

        
        public double GetNearestObstacleDistance(List<SensorReading> readings)
        {
            return readings
                   .Where(r => r.Type == "Distance")
                   .Select(r => r.Value)
                   .DefaultIfEmpty(double.MaxValue)
                   .Min();
        }

        
        public bool IsTemperatureSafe(List<SensorReading> readings)
        {
            return readings
                   .Where(r => r.Type == "Temperature")
                   .All(r => r.Value < 90);
        }

        
        public double GetAverageVibration(List<SensorReading> readings)
        {
            return readings
                   .Where(r => r.Type == "Vibration")
                   .Select(r => r.Value)
                   .DefaultIfEmpty(0)
                   .Average();
        }

        
        public Dictionary<string, double> CalculateSensorHealth(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                   .GroupBy(r => r.Type)
                   .ToDictionary(
                       g => g.Key,
                       g => g.Average(r => r.Confidence)
                   );
        }

        
        public List<string> DetectFaultySensors(List<SensorReading> sensorHistory)
        {
            return sensorHistory
                   .Where(r => r.Confidence < 0.4)
                   .GroupBy(r => r.Type)
                   .Where(g => g.Count() > 2)
                   .Select(g => g.Key)
                   .ToList();
        }

        
        public bool IsBatteryDrainingFast(List<SensorReading> sensorHistory)
        {
            var batteryValues = sensorHistory
                                .Where(r => r.Type == "Battery")
                                .OrderBy(r => r.Timestamp)
                                .Select(r => r.Value)
                                .ToList();

            return batteryValues
                   .Zip(batteryValues.Skip(1), (a, b) => b < a)
                   .All(x => x);
        }

        
        public double GetWeightedDistance(List<SensorReading> readings)
        {
            var distanceReadings = readings.Where(r => r.Type == "Distance");

            double weightedSum = distanceReadings.Sum(r => r.Value * r.Confidence);
            double totalConfidence = distanceReadings.Sum(r => r.Confidence);

            if (totalConfidence == 0)
                return double.MaxValue;

            return weightedSum / totalConfidence;
        }

        
        public RobotAction DecideRobotAction(List<SensorReading> recentReadings, List<SensorReading> sensorHistory)
        {
            if (recentReadings.Any(r => r.Type == "Battery" && r.Value < 20))
                return RobotAction.Stop;

            if (IsBatteryDrainingFast(sensorHistory))
                return RobotAction.Stop;

            if (GetNearestObstacleDistance(recentReadings) < 1.0)
                return RobotAction.Reroute;

            if (recentReadings.Any(r => r.Type == "Temperature" && r.Value >= 90))
                return RobotAction.SlowDown;

            return RobotAction.Continue;
        }
    }

    class Main5
    {
        static void Main()
        {
            List<SensorReading> sensorHistory = new List<SensorReading>
            {
                new SensorReading { SensorId=1, Type="Distance", Value=0.8, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-9)},
                new SensorReading { SensorId=2, Type="Battery", Value=18, Confidence=0.8, Timestamp=DateTime.Now.AddSeconds(-8)},
                new SensorReading { SensorId=3, Type="Temperature", Value=92, Confidence=0.7, Timestamp=DateTime.Now.AddSeconds(-7)},
                new SensorReading { SensorId=4, Type="Vibration", Value=8.2, Confidence=0.6, Timestamp=DateTime.Now.AddSeconds(-6)},
                new SensorReading { SensorId=5, Type="Battery", Value=75, Confidence=0.9, Timestamp=DateTime.Now.AddSeconds(-5)},
                new SensorReading { SensorId=6, Type="Distance", Value=2.5, Confidence=0.5, Timestamp=DateTime.Now.AddSeconds(-4)}
            };

            DecisionEngine engine = new DecisionEngine();
            DateTime fromTime = DateTime.Now.AddSeconds(-10);

            
            var recentReadings = engine.GetRecentReadings(sensorHistory, fromTime);
            var batteryCritical = engine.IsBatteryCritical(recentReadings);
            var nearestDistance = engine.GetNearestObstacleDistance(recentReadings);
            var temperatureSafe = engine.IsTemperatureSafe(recentReadings);
            var avgVibration = engine.GetAverageVibration(recentReadings);
            var sensorHealth = engine.CalculateSensorHealth(sensorHistory);
            var faultySensors = engine.DetectFaultySensors(sensorHistory);
            var batteryDraining = engine.IsBatteryDrainingFast(sensorHistory);
            var weightedDistance = engine.GetWeightedDistance(recentReadings);
            var finalAction = engine.DecideRobotAction(recentReadings, sensorHistory);

            Console.WriteLine($"Final Robot Action: {finalAction}");
        }
    }
}
