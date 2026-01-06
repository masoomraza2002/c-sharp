using System;
using System.Collections.Generic;

namespace SmartHomeSecurity
{
    // 1. DEFINITION: The "Contract" for any security response.
    // Any method responding to an alert must be void and take a string location.

    public delegate void SecurityAction(string zone); // definition

    public class MotionSensor
    {
        // The delegate instance (The Panic Button)
        public SecurityAction OnEmergency; // instance creation

        public void DetectIntruder(string zoneName)
        {
            Console.WriteLine($"[SENSOR] Motion detected in {zoneName}!");

            // 3. INVOCATION: Triggering the Panic Button
            if (OnEmergency != null)
            {
                OnEmergency(zoneName); // string value = Main Lobby or panicSequence?
            }
        }
    }

    // Diverse classes that don't know about each other
    public class AlarmSystem
    {
        public void SoundSiren(string zone) => Console.WriteLine($"[ALARM] WOO-OOO! High-decibel siren active in {zone}.");
    }

    public class PoliceNotifier
    {
        public void CallDispatch(string zone) => Console.WriteLine($"[POLICE] Notifying local precinct of intrusion in {zone}.");
    }

    class Program
    {
        static void Main()
        {
            // Objects Initialization
            MotionSensor livingRoomSensor = new MotionSensor();
            AlarmSystem siren = new AlarmSystem();
            PoliceNotifier police = new PoliceNotifier();

            // 2. INSTANTIATION & MULTICASTING
            // We "Subscribe" different methods to the sensor's delegate
            SecurityAction panicSequence = siren.SoundSiren; // Assignment of methods
            panicSequence += police.CallDispatch;

            // Linking the sequence to the sensor
            livingRoomSensor.OnEmergency = panicSequence;
            // class_object.delegate_instance = delegate_instance_multicast

            // Simulation
            livingRoomSensor.DetectIntruder("Main Lobby");
        }
    }
}
