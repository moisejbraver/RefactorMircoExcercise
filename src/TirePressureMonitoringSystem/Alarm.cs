namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        /// <summary>
        /// Gets the low pressure threshold.
        /// </summary>
        /// <value>
        /// The low pressure threshold.
        /// </value>
        public double LowPressureThreshold { get; }

        /// <summary>
        /// Gets the high pressure threshold.
        /// </summary>
        /// <value>
        /// The high pressure threshold.
        /// </value>
        public double HighPressureThreshold { get; }

        /// <summary>
        /// Gets a value indicating whether alarm is on.
        /// </summary>
        /// <value>
        ///   <c>true</c> if alarm is on; otherwise, <c>false</c>.
        /// </value>
        public bool AlarmOn { get; private set; } = false;

        readonly Sensor _sensor = new Sensor();

        /// <summary>
        /// Initializes a new instance of the <see cref="Alarm"/> class.
        /// </summary>
        /// <param name="lowPressureThreshold">The low pressure threshold.</param>
        /// <param name="highPressureThreshold">The high pressure threshold.</param>
        public Alarm(double lowPressureThreshold = 17, double highPressureThreshold = 21)
        {
            LowPressureThreshold = lowPressureThreshold;
            HighPressureThreshold = highPressureThreshold;
        }

        /// <summary>
        /// Checks the sensor's pressure.
        /// </summary>
        /// <param name="psiPressureValue">The psi pressure value.</param>
        public void Check()
        {
            double psiPressureThreshold = _sensor.PopNextPressurePsiValue();
            Check(psiPressureThreshold);
        }

        /// <summary>
        /// Checks the specified psi pressure threshold.
        /// </summary>
        /// <param name="psiPressureThreshold">The psi pressure threshold.</param>
        public void Check(double psiPressureThreshold)
        {
            if (psiPressureThreshold < LowPressureThreshold || HighPressureThreshold < psiPressureThreshold)
            {
                AlarmOn = true;
            }
        }
    }
}
