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
        //private Square m_sCurrentSquare;
        private Square[] m_asPath;
        private int m_iCurrentPosition;

        public RobotBDI(string p_sName, int p_iCompteurPoints, Square[] p_asPathArray)
        {
            m_iCompteurPoints = p_iCompteurPoints;
            m_sName = p_sName;
            m_asPath = p_asPathArray;
        }

        public void Move()
        {
            if(m_asPath != null)
            {
                if (m_iCurrentPosition < m_asPath.Length)
                {
                    m_iCurrentPosition++;
                    m_iCompteurPoints--;
                }
            }
        }

        public void Scan()
        {

        }

    }
}
