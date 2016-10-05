using Environment;
using MainProgram;
using System.Collections.Generic;
using System.Threading;

namespace VacuumRobot
{
    /// <summary>
    /// Create a new RobotAI.
    /// </summary>
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
        /// Return the current state of the Environment from the robot's point of view.
        /// The state of the Environment can return the following values :
        /// 0 : Nothing on the Square.
        /// 1 : Only dust on the Square.
        /// 2 : Only jewels on the Square.
        /// 3 : Both dust and jewel on the Square.
        /// </summary>
        /// <returns> Return an int array as followed [Index of the current Square, State of the current Square]. </returns>
        public int[] EnvironmentState()
        {
            bool bDust = Sensor.HasDust(m_asPathArray[m_iCurrentPositionIndex]);
            bool bJewel = Sensor.HasJewel(m_asPathArray[m_iCurrentPositionIndex]);

            int iResultState = 0;

            if ((bDust == true) && (bJewel = false))
            {
                iResultState = 1;
            }
            if ((bDust == false) && (bJewel = true))
            {
                iResultState = 2;
            }
            if ((bDust == true) && (bJewel = true))
            {
                iResultState = 3;
            }

            int[] aiResult = { m_iCurrentPositionIndex, iResultState };

            return aiResult;
        }

        /// <summary>
        /// Remove dust from the current square.
        /// </summary>
        public void removeDust()
        {
            int iTimerIndex = 0;
            while (iTimerIndex < 50)
            {
                Actuator.PickUpDust(m_asPathArray[m_iCurrentPositionIndex]);
                Actuator.PickUpJewel(m_asPathArray[m_iCurrentPositionIndex]);
                Thread.Sleep(20);
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

        /// <summary>
        /// Processes the action the agent MAY undertake, given a state of the environment.
        /// </summary>
        /// <param name="p_iStateEnv"> The current state of the environment. </param>
        /// <returns> The list of every action possible for the agent. </returns>
        public List<ActionPossible> actionDeclenchable(int[] p_iStateEnv)
        {
            // Declares the four possible actions, and add them to the list of possible actions.
            ActionPossible aActToSuck = new Aspirate();
            ActionPossible aActToMove = new MoveRobot();
            ActionPossible aActToGrab = new Grab();
            ActionPossible aActToDoNothing = new DoNothing();
            List<ActionPossible> aListActionPossible = null;
            aListActionPossible.Add(aActToSuck);
            aListActionPossible.Add(aActToMove);
            aListActionPossible.Add(aActToGrab);
            aListActionPossible.Add(aActToDoNothing);

            // If the environment is composed of dust only.
            if (p_iStateEnv[1] == 0)
            {
                /* Here we would delete the actions that the agent
                 * can't undertake in the current environment. 
                 * In our situation, all action are theoritically possible however. */
            }
            // If the environment is composed of jewels only
            if (p_iStateEnv[1] == 1)
            {
                /* Here we would delete the actions that the agent
                 * can't undertake in the current environment. 
                 * In our situation, all action are theoritically possible however. */
            }
            // If the environment is composed of dust and jewels.
            if (p_iStateEnv[1] == 2)
            {
                /* Here we would delete the actions that the agent
                 * can't undertake in the current environment. 
                 * In our situation, all action are theoritically possible however. */
            }
            // If the environment is composed of neither dust or jewels
            if (p_iStateEnv[1] == 3)
            {
                /* Here we would delete the actions that the agent
                 * can't undertake in the current environment. 
                 * In our situation, all action are theoritically possible however. */
            }
            return aListActionPossible;
        }

        /// <summary>
        /// Choose an action for the agent to perform, based on its goal and environment.
        /// </summary>
        /// <param name="p_iStateEnv"> Current state of the environment surrounding the agent. </param>
        /// <param name="p_iMyGoal"> Current goal the agent is trying to achieve. </param>
        /// <returns> The best choice action in the current context, that will help the agent to achieve its goal. </returns>
        public ActionPossible DetermineActionUponMyGoal(int[] p_iStateEnv, int p_iMyGoal)
        {
            // This list contains each possible action for the agent, regardless of their relevance
            List<ActionPossible> lapListActionPossible = actionDeclenchable(p_iStateEnv);

            // Initialises the index used to keep track of the best action to perform.
            int iIndexActionToDo = -1;

            for (int i = 0; i < lapListActionPossible.Count; i++)
            {
                // Each iteration, initialises the worthiness of the action currently evaluated.
                int iWorthiness = -1;

                if (iWorthiness < CalculateWorthiness(lapListActionPossible[i], p_iMyGoal, p_iStateEnv))
                {
                    // If the current action is the most relevant, we keep its index in the list.
                    iIndexActionToDo = i;
                }
            }
            // When we went through the whole list, the index returned is the one of the most relevant action.
            return lapListActionPossible[iIndexActionToDo];
        }

        /// <summary>
        /// Calculate the worthiness of an action, based on the parameters given.
        /// </summary>
        /// <param name="p_apAction"> Input action that needs to be evaluated. </param>
        /// <param name="p_iMyGoal"> Current goal the agent is trying to achieve. </param>
        /// <param name="p_aiStateEnv"> Current state of the environment surrounding the agent. </param>
        /// <returns> Returns the optimal worthiness calculated for the specified action. </returns>
        public int CalculateWorthiness(ActionPossible p_apAction, int p_iMyGoal, int[] p_aiStateEnv)
        {
            // Initialises several counter for worthiness, each associated with a different goal
            int iWorthinessRegardingJewels = -1;
            int iWorthinessRegardingElectricity = -1;
            int iWorthinessRegardingCleanliness = -1;

            /* Depending on the state of the environment and the goal, we logically attibute a number of point to each counter
             * This way, a particularly interesting action to perform will be set a high value of worthiness */
            switch (p_aiStateEnv[1])
            {
                // If there is dust only
                case 0:
                    if (p_apAction.Name == "Aspirate")
                    {
                        iWorthinessRegardingJewels = 5; iWorthinessRegardingElectricity = 1; iWorthinessRegardingCleanliness = 5;
                    }
                    if (p_apAction.Name == "MoveRobot")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 0;
                    }
                    if (p_apAction.Name == "Grab")
                    {
                        iWorthinessRegardingJewels = 1; iWorthinessRegardingElectricity = 1; iWorthinessRegardingCleanliness = 3;
                    }
                    if (p_apAction.Name == "DoNothing")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 5; iWorthinessRegardingCleanliness = 0;
                    }
                    break;
                // If there is jewels only
                case 1:
                    if (p_apAction.Name == "Aspirate")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 1; iWorthinessRegardingCleanliness = 3;
                    }
                    if (p_apAction.Name == "MoveRobot")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 0;
                    }
                    if (p_apAction.Name == "Grab")
                    {
                        iWorthinessRegardingJewels = 5; iWorthinessRegardingElectricity = 1; iWorthinessRegardingCleanliness = 3;
                    }
                    if (p_apAction.Name == "DoNothing")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 5; iWorthinessRegardingCleanliness = 0;
                    }
                    break;
                // If there both dust and jewels
                case 2:
                    if (p_apAction.Name == "Aspirate")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 1; iWorthinessRegardingCleanliness = 5;
                    }
                    if (p_apAction.Name == "MoveRobot")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 0;
                    }
                    if (p_apAction.Name == "Grab")
                    {
                        iWorthinessRegardingJewels = 5; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 1;
                    }
                    if (p_apAction.Name == "DoNothing")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 5; iWorthinessRegardingCleanliness = 0;
                    }
                    break;
                // If there is nothing on the square
                case 3:
                    if (p_apAction.Name == "Aspirate")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 0;
                    }
                    if (p_apAction.Name == "MoveRobot")
                    {
                        iWorthinessRegardingJewels = 3; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 3;
                    }
                    if (p_apAction.Name == "Grab")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 0; iWorthinessRegardingCleanliness = 0;
                    }
                    if (p_apAction.Name == "DoNothing")
                    {
                        iWorthinessRegardingJewels = 0; iWorthinessRegardingElectricity = 5; iWorthinessRegardingCleanliness = 0;
                    }
                    break;
                default:
                    break;
            }
            // Then, we return the counter associated with the current goal of the agent
            int result;
            if (p_iMyGoal == 0)
            {
                result = iWorthinessRegardingJewels;
            }
            else if (p_iMyGoal == 1)
            {
                result = iWorthinessRegardingCleanliness;
            }
            else if (p_iMyGoal == 2)
            {
                result = iWorthinessRegardingElectricity;
            }
            else
            {
                result = -1;
            }
            return result;
        }
    }
}
