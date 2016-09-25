using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment;

namespace VacuumRobot
{
    public class Actuator
    {
        /// <summary>
        /// Pick up the jewel from the current square.
        /// </summary>
        /// <param name="p_sSquare"> The current square. </param>
        public void PickUpJewel(Case p_sSquare)
        {
            p_sSquare.HasJewel = false;
        }

        /// <summary>
        /// Pick up the dust from the current square.
        /// </summary>
        /// <param name="p_sSquare">  The current square. </param>
        public void PickUpDust(Case p_sSquare)
        {
            p_sSquare.HasDust = false;
        }
    }
}
