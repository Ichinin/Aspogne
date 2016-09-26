﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment;

namespace VacuumRobot
{
    public class Sensor
    {
        /// <summary>
        /// Return true if the current case contains some dust, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public bool HasDust(Case p_sSquare)
        {
            return p_sSquare.HasDust;
        }

        /// <summary>
        /// Return true if the current case contains some jewels, false otherwise.
        /// </summary>
        /// <param name="p_sSquare"> The case to scan. </param>
        /// <returns></returns>
        public bool HasJewel(Case p_sSquare)
        {
            return p_sSquare.HasJewel;
        }
    }
}