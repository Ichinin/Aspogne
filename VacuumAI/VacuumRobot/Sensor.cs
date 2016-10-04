using Environment;

namespace VacuumRobot
{
    public static class Sensor
    {
        /// <summary>
        /// True if the sensor detected some dust, false otherwise.
        /// </summary>
        private static  bool m_bDustDetected = false;
        /// <summary>
        /// True if the sensor detected some jewel, false otherwise.
        /// </summary>
        private static bool m_bJewelDetected = false;

        /// <summary>
        /// Get / set the detection of dust.
        /// </summary>
        public static bool DustDetected
        {
            get
            {
                return m_bDustDetected;
            }
            set
            {
                m_bDustDetected = value;
            }
        }

        /// <summary>
        /// Get / set the detection of jewel.
        /// </summary>
        public static bool JewelDetected
        {
            get
            {
                return m_bJewelDetected;
            }
            set
            {
                m_bJewelDetected = value;
            }
        }

        /// <summary>
        /// Return true if the current case contains some dust, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public static bool HasDust(Square p_sSquare)
        {
            DustDetected = p_sSquare.HasDust;
            return DustDetected;
        }

        /// <summary>
        /// Return true if the current case contains some jewels, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public static bool HasJewel(Square p_sSquare)
        {
            JewelDetected = p_sSquare.HasJewel;
            return JewelDetected;
        }
    }
}
