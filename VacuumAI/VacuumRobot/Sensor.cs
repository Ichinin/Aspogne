using Environment;

namespace VacuumRobot
{
    public static class Sensor
    {
        /// <summary>
        /// Return true if the current case contains some dust, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public static bool HasDust(Square p_sSquare)
        {
            return p_sSquare.HasDust;
        }

        /// <summary>
        /// Return true if the current case contains some jewels, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public static bool HasJewel(Square p_sSquare)
        {
            return p_sSquare.HasJewel;
        }
    }
}
