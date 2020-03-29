using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestClass()]
    public class AlarmTests
    {        
        [TestMethod()]
        public void AlarmIsOffByDefault()
        {
            Assert.IsFalse((new Alarm()).AlarmOn);
        }

        [TestMethod()]
        public void CheckSetsAlarmOnWhenPressureIsTooLow()
        {
            // simulate sensor values until we get a value that is less
            // than the lower threshold
            var alarm = new Alarm();
            var lowPressure = alarm.LowPressureThreshold - 1;
            alarm.Check(lowPressure);

            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod()]
        public void CheckSetsAlarmOnWhenPressureIsTooHigh()
        {
            var alarm = new Alarm();
            var highPressure = alarm.HighPressureThreshold + 1;
            alarm.Check(highPressure);

            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod()]
        public void CheckKeepsAlarmOffWhenPressureIsNormal()
        {
            var alarm = new Alarm();
            var normalPressure = alarm.LowPressureThreshold + 1;
            alarm.Check(normalPressure);

            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod()]
        public void CheckTurnsAlarmOffWhenPressureRestoresToNormal()
        {
            var alarm = new Alarm();
            var lowPressure = alarm.LowPressureThreshold - 1;
            alarm.Check(lowPressure);
            Assert.IsTrue(alarm.AlarmOn);

            var normalPressure = alarm.LowPressureThreshold + 1;
            alarm.Check(normalPressure);
            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}