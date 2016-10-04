using Environment;

namespace VacuumRobot
{
    public static class Actuator
    {
        /// <summary>
        /// Pick up the jewel from the current square.
        /// </summary>
        /// <param name="p_sSquare"> The current square. </param>
        public static void PickUpJewel(Square p_sSquare)
        {
            p_sSquare.HasJewel = false;
        }

        /// <summary>
        /// Pick up the dust from the current square.
        /// </summary>
        /// <param name="p_sSquare">  The current square. </param>
        public static void PickUpDust(Square p_sSquare)
        {
            p_sSquare.HasDust = false;
        }
    }
}
