using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment;

namespace VacuumRobot
{
    public class RobotBDI
    {
        private string m_sName;
        private int m_iCompteurPoints;
        private Square[] m_asPathArray = null;
        private int m_iCurrentPositionIndex = 0;
        //private Sensor sens = new Sensor();

        public int CompteurPoints
        {
            set
            {
                CompteurPoints = value;
            }
        }

        public RobotBDI(string p_sName, int p_iCompteurPoints, Square[] p_asPathArray)
        {
            m_iCompteurPoints = p_iCompteurPoints;
            m_sName = p_sName;
            m_asPathArray = p_asPathArray;
        }

        public void Move()
        {
            if(m_asPathArray != null)
            {
                if (m_iCurrentPositionIndex < m_asPathArray.Length)
                {
                    m_asPathArray[m_iCurrentPositionIndex].HasVacuum = false;
                    m_iCurrentPositionIndex++;
                    m_iCompteurPoints--;
                }
            }
        }

        public bool[] Scan()
        {
            //bool[] result = new bool[2];

            //bool[] result = { Sensor.HasDust(m_asPathArray[m_iCurrentPositionIndex]), Sensor.hasJewel(m_asPathArray[m_iCurrentPositionIndex]) };
            //return result;
        }

    }
}
