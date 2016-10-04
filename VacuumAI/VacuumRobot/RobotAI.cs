using Environment;
using System.Threading;

namespace VacuumRobot
{
    public class RobotAI
    {
        /// <summary>
        /// Name of the robot.
        /// </summary>
        private string m_sName;
        /// <summary>
        /// Nomber of points of the robot. Robot dies if it reaches 0.
        /// Each action deplete this number by one unit.
        /// </summary>
        private int m_iPointsCount;
        /// <summary>
        /// Path the robot will follow through the environment.
        /// </summary>
        private Square[] m_asPathArray = null;
        /// <summary>
        /// Current index in the m_asPathArray array.
        /// </summary>
        private int m_iCurrentPositionIndex = 0;

        /// <summary>
        /// Set the number of points.
        /// </summary>
        public int PointsCount
        {
            set
            {
                m_iPointsCount = value;
            }
        }

        /// <summary>
        /// Create a new robot AI.
        /// </summary>
        /// <param name="p_sName"> Robot name. </param>
        /// <param name="p_iPointsCount"> Robot point count. </param>
        /// <param name="p_asPathArray"> Path that will be followed by the robot. </param>
        public RobotAI(string p_sName, int p_iPointsCount, Square[] p_asPathArray)
        {
            m_iPointsCount = p_iPointsCount;
            m_sName = p_sName;
            m_asPathArray = p_asPathArray;
        }

        /// <summary>
        /// Finds out if the robot is still alive, i.e. if its PointsCount is superior to 0.
        /// </summary>
        /// <returns> Return true if the robot is still alive. </returns>
        public bool AmIAlive()
        {
            bool result = false;
            if (m_iPointsCount > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Move the robot to the next square in m_asPathArray.
        /// </summary>
        public void Move()
        {
            if (m_asPathArray != null)
            {
                m_asPathArray[m_iCurrentPositionIndex].HasVacuum = false;
                if (m_iCurrentPositionIndex < m_asPathArray.Length)
                {
                    m_iCurrentPositionIndex++;
                }
                else
                {
                    m_iCurrentPositionIndex = 0;
                }
                m_iPointsCount--;
                m_asPathArray[m_iCurrentPositionIndex].HasVacuum = true;
            }
        }

        /// <summary>
        /// Return the current square content.
        /// </summary>
        /// <returns> Return a boolean array as followed [Is there dust in the current square ?, Is there jewel in the current square ?]. </returns>
        public bool[] Scan()
        {
            bool[] baResult = { Sensor.HasDust(m_asPathArray[m_iCurrentPositionIndex]), Sensor.HasJewel(m_asPathArray[m_iCurrentPositionIndex]) };
            return baResult;
        }

        /// <summary>
        /// Remove dust from the current square.
        /// </summary>
        public void removeDust()
        {
            int iTimerIndex = 0;
            while (iTimerIndex < 50)
            {
                Thread.Sleep(20);
                Actuator.PickUpDust(m_asPathArray[m_iCurrentPositionIndex]);
                Actuator.PickUpJewel(m_asPathArray[m_iCurrentPositionIndex]);
                iTimerIndex++;
            }
            // Add 2 points and remove 1 for action.
            //m_iPointsCount--;
            m_iPointsCount++;
        }

        /// <summary>
        /// Remove jewel from the current square.
        /// </summary>
        public void RemoveJewel()
        {
            Actuator.PickUpJewel(m_asPathArray[m_iCurrentPositionIndex]);
            // Add 4 points and remove 1 for action.
            //m_iPointsCount--;
            m_iPointsCount = m_iPointsCount + 3;
        }

    }
}
