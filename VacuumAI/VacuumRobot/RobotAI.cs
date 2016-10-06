using Environment;
using MainProgram;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace VacuumRobot
{
    /// <summary>
    /// The class creates a new Robot AI and its control panel.
    /// </summary>
    public partial class RobotAI : Form
    {
        /// <summary>
        /// Name of the robot.
        /// </summary>
        private string m_sName = null;
        /// <summary>
        /// Nomber of points of the robot. Robot dies if it reaches 0.
        /// Each action deplete this number by one unit.
        /// </summary>
        private int m_iPointsCount = -1;
        /// <summary>
        /// Path the robot will follow through the environment.
        /// </summary>
        private Square[] m_asPathArray = null;
        /// <summary>
        /// Current index in the m_asPathArray array.
        /// </summary>
        private int m_iCurrentPositionIndex = 0;
        /// <summary>
        /// Store in a temporary memory (1 timer cycle) whether the square contains dust or not.
        /// </summary>
        private bool m_bDustDetected = false;
        /// <summary>
        /// Store in a temporary memory (1 timer cycle) whether the square contains jewel or not.
        /// </summary>
        private bool m_bJewelDetected = false;
        /// <summary>
        /// Set the goal to be reached by the robot.
        /// The possible options are :
        /// 0 : The robot will focus on cleaning the room and picking up the jewels without caring for time or energy wasted.
        /// 1 : The robot will go as fast as possible, hoovering both dust and jewels.
        /// 2 : The robot will save as much energy as possible, staying on the same spot as a result.
        /// </summary>
        private int m_iGoal = -1;

        /// <summary>
        /// Get the goal of the robot.
        /// </summary>
        public int Goal
        {
            get
            {
                return m_iGoal;
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
            InitializeComponent();
            this.Text = p_sName;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            m_iPointsCount = p_iPointsCount;
            m_sName = p_sName;
            m_asPathArray = p_asPathArray;

            // Initialise the textBox with starting values.
            textBoxDust.Text = m_bDustDetected.ToString();
            textBoxJewel.Text = m_bJewelDetected.ToString();
            textBoxPoint.Text = m_iPointsCount.ToString();
            textBoxPosition.Text = "Case " + m_asPathArray[0].NumSquare.ToString();

            // Initialise the comboBoxGoal.
            comboBoxGoal.Items.Add("Grab jewels and hoover dust");
            comboBoxGoal.Items.Add("Go as fast as you can");
            comboBoxGoal.Items.Add("Save some energy for later");
            comboBoxGoal.SelectedIndex = 0;
            comboBoxGoal.Enabled = true;
        }

        /// <summary>
        /// Thread-safe function to read the value from a winform control.
        /// </summary>
        /// <param name="varControl"> Control to read the text from. </param>
        /// <returns></returns>
        private static string readControlText(Control varControl)
        {
            if (varControl.InvokeRequired)
            {
                return (string)varControl.Invoke(
                  new Func<String>(() => readControlText(varControl))
                );
            }
            else
            {
                string varText = varControl.Text;
                return varText;
            }
        }

        /// <summary>
        /// Delegate to invoke a thread-safe function to set the text of a Control.
        /// </summary>
        /// <param name="varControl"> The control whose text need to be changed </param>
        /// <param name="text"> The new text </param>
        delegate void SetTextCallback(Control varControl, string text);

        /// <summary>
        /// Thread-safe function to set the text of a Control.
        /// </summary>
        /// <param name="varControl"> The control whose text need to be changed </param>
        /// <param name="text"> The new text </param>
        private void SetControlText(Control varControl, string text)
        {
            if (varControl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetControlText);
                this.Invoke(d, new object[] { varControl, text });
            }
            else
            {
                varControl.Text = text;
            }
        }

        /// <summary>
        /// Finds out if the robot is still alive, i.e. if its PointsCount is superior to 0.
        /// </summary>
        /// <returns> Return true if the robot is still alive. </returns>
        public bool AmIAlive()
        {
            

            SetControlText(textBoxDust, m_bDustDetected.ToString());
            SetControlText(textBoxJewel, m_bJewelDetected.ToString());

            bool bResult = false;
            if (m_iPointsCount > 0)
            {
                bResult = true;
            }
            return bResult;
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
        public int[] GetEnvironmentState()
        {
            m_bDustDetected = Sensor.HasDust(m_asPathArray[m_iCurrentPositionIndex]);
            m_bJewelDetected = Sensor.HasJewel(m_asPathArray[m_iCurrentPositionIndex]);

            SetControlText(textBoxDust, m_bDustDetected.ToString());
            SetControlText(textBoxJewel, m_bJewelDetected.ToString());

            int iResultState = 0;

            if ((m_bDustDetected == true) && (m_bJewelDetected == false))
            {
                iResultState = 1;
            }
            if ((m_bDustDetected == false) && (m_bJewelDetected == true))
            {
                iResultState = 2;
            }
            if ((m_bDustDetected == true) && (m_bJewelDetected == true))
            {
                iResultState = 3;
            }

            int[] aiResult = { m_iCurrentPositionIndex, iResultState };
            return aiResult;
        }

        /// <summary>
        /// Move the robot to the next square in m_asPathArray.
        /// </summary>
        public void MoveRobot()
        {
            // Reset the detection result on each cycle.
            m_bDustDetected = false;
            m_bJewelDetected = false;

            if (m_asPathArray != null)
            {
                m_asPathArray[m_iCurrentPositionIndex].HasVacuum = false;

                if (m_iCurrentPositionIndex < (m_asPathArray.Length - 1))
                {
                    m_iCurrentPositionIndex++;

                    SetControlText(textBoxPosition, m_asPathArray[m_iCurrentPositionIndex].NumSquare.ToString());
                    Console.Write("Robot moving from square " + m_asPathArray[m_iCurrentPositionIndex - 1].NumSquare +
                    " to square " + m_asPathArray[m_iCurrentPositionIndex].NumSquare + "\n");
                }
                else
                {
                    SetControlText(textBoxPosition, m_asPathArray[0].NumSquare.ToString());
                    Console.Write("Robot moving from square " + m_asPathArray[m_iCurrentPositionIndex].NumSquare +
                    " to square " + m_asPathArray[0].NumSquare + "\n");
                    m_iCurrentPositionIndex = 0;
                }
                m_iPointsCount--;
                SetControlText(textBoxPoint, m_iPointsCount.ToString());
                Console.Write("Arrived in new room. New points count : " + m_iPointsCount + "\n");
                m_asPathArray[m_iCurrentPositionIndex].HasVacuum = true;
            }
        }

        /// <summary>
        /// Remove dust from the current square.
        /// </summary>
        public void HooverEverything()
        {
            Console.Write("Hoovering in progress...\n");
            Thread.Sleep(500);
            Actuator.PickUpDust(m_asPathArray[m_iCurrentPositionIndex]);
            if (m_bJewelDetected)
            {
                m_iPointsCount -= 10;
                SetControlText(textBoxPoint, m_iPointsCount.ToString());
            }
            Actuator.PickUpJewel(m_asPathArray[m_iCurrentPositionIndex]);
            SetControlText(textBoxPoint, m_iPointsCount.ToString());
            Console.Write("Hoovering done. New points count : " + m_iPointsCount + "\n");
        }

        /// <summary>
        /// Remove jewel from the current square.
        /// </summary>
        public void PickUpJewel()
        {
            Console.Write("Picking up jewels...\n");
            Thread.Sleep(1000);
            Actuator.PickUpJewel(m_asPathArray[m_iCurrentPositionIndex]);
            // Add 6 points and remove 1 for action.
            //m_iPointsCount--;
            m_iPointsCount += 5;
            SetControlText(textBoxPoint, m_iPointsCount.ToString());
            Console.Write("Picking jewels done. New points count : " + m_iPointsCount + "\n");
        }

        /// <summary>
        /// Processes the action the agent MAY undertake, given a state of the environment.
        /// </summary>
        /// <param name="p_iStateEnv"> The current state of the environment. </param>
        /// <returns> The list of every action possible for the agent. </returns>
        private List<ActionPossible> ActionDeclenchable(int[] p_iStateEnv)
        {
            // Declares the four possible actions, and add them to the list of possible actions.
            Aspirate apActToSuck = new Aspirate(this);
            MoveRobot apActToMove = new MoveRobot(this);
            Grab apActToGrab = new Grab(this);
            DoNothing apActToDoNothing = new DoNothing(this);
            List<ActionPossible> aListActionPossible = new List<ActionPossible>();
            aListActionPossible.Add(apActToSuck);
            aListActionPossible.Add(apActToMove);
            aListActionPossible.Add(apActToGrab);
            aListActionPossible.Add(apActToDoNothing);

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
        /// <param name="p_aiStateEnv"> Current state of the environment surrounding the agent. </param>
        /// <returns> The best choice action in the current context, that will help the agent to achieve its goal. </returns>
        public ActionPossible DetermineActionUponMyGoal(int[] p_aiStateEnv)
        {
            string sComboBoxGoalText = readControlText(comboBoxGoal);

            if (sComboBoxGoalText == "Grab jewels and hoover dust")
            {
                m_iGoal = 0;
            }
            else if (sComboBoxGoalText == "Go as fast as you can")
            {
                m_iGoal = 1;
            }
            else if (sComboBoxGoalText == "Save some energy for later")
            {
                m_iGoal = 2;
            }

            // This list contains each possible action for the agent, regardless of their relevance
            List<ActionPossible> lapListActionPossible = ActionDeclenchable(p_aiStateEnv);

            // Initialises the index used to keep track of the best action to perform.
            int iIndexActionToDo = -1;

            // Each iteration, initialises the worthiness of the action currently evaluated.
            int iWorthiness = -1;

            for (int i = 0; i < lapListActionPossible.Count; i++)
            {
                if (iWorthiness < CalculateWorthiness(lapListActionPossible[i], m_iGoal, p_aiStateEnv))
                {
                    iWorthiness = CalculateWorthiness(lapListActionPossible[i], m_iGoal, p_aiStateEnv);
                    // If the current action is the most relevant, we keep its index in the list.
                    iIndexActionToDo = i;
                }
            }
            // When we went through the whole list, the index returned is the one of the most relevant action.
            return lapListActionPossible[iIndexActionToDo];
        }

        /// <summary>
        /// Perform the action which appear to be the most interesting to reach the robot's goal.
        /// </summary>
        /// <param name="p_apAction"> The action to perform. </param>
        public void DoAction(ActionPossible p_apAction)
        {
            p_apAction.Act();
        }

        /// <summary>
        /// Calculate the worthiness of an action, based on the parameters given.
        /// </summary>
        /// <param name="p_apAction"> Input action that needs to be evaluated. </param>
        /// <param name="p_iMyGoal"> Current goal the agent is trying to achieve. </param>
        /// <param name="p_aiStateEnv"> Current state of the environment surrounding the agent. </param>
        /// <returns> Returns the optimal worthiness calculated for the specified action. </returns>
        private int CalculateWorthiness(ActionPossible p_apAction, int p_iMyGoal, int[] p_aiStateEnv)
        {
            // Initialises several counter for worthiness, each associated with a different goal
            int iWorthinessRegardingJewelsAndCleanliness = -1;
            int iWorthinessRegardingSpeed = -1;
            int iWorthinessRegardingElectricitySave = -1;

            /* Depending on the state of the environment and the goal, we logically attibute a number of point to each counter
             * This way, a particularly interesting action to perform will be set a high value of worthiness */
            switch (p_aiStateEnv[1])
            {
                // If there is nothing on the Square.
                case 0:
                    if (p_apAction.Name() == "Aspirate")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "MoveRobot")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 1; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 1;
                    }
                    if (p_apAction.Name() == "Grab")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "DoNothing")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 1; iWorthinessRegardingSpeed = 0;
                    }
                    break;
                // If there is dust only.
                case 1:
                    if (p_apAction.Name() == "Aspirate")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 1; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 1;
                    }
                    if (p_apAction.Name() == "MoveRobot")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "Grab")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "DoNothing")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 1; iWorthinessRegardingSpeed = 0;
                    }
                    break;
                // If there are jewels only.
                case 2:
                    if (p_apAction.Name() == "Aspirate")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 1;
                    }
                    if (p_apAction.Name() == "MoveRobot")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "Grab")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 1; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "DoNothing")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 1; iWorthinessRegardingSpeed = 0;
                    }
                    break;
                // If there are both jewels and dust.
                case 3:
                    if (p_apAction.Name() == "Aspirate")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 1;
                    }
                    if (p_apAction.Name() == "MoveRobot")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "Grab")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 1; iWorthinessRegardingElectricitySave = 0; iWorthinessRegardingSpeed = 0;
                    }
                    if (p_apAction.Name() == "DoNothing")
                    {
                        iWorthinessRegardingJewelsAndCleanliness = 0; iWorthinessRegardingElectricitySave = 1; iWorthinessRegardingSpeed = 0;
                    }
                    break;
                default:
                    break;
            }

            // Then, we return the counter associated with the current goal of the agent.
            int iResult = -1;
            if (p_iMyGoal == 0)
            {
                iResult = iWorthinessRegardingJewelsAndCleanliness;
            }
            else if (p_iMyGoal == 1)
            {
                iResult = iWorthinessRegardingSpeed;
            }
            else if (p_iMyGoal == 2)
            {
                iResult = iWorthinessRegardingElectricitySave;
            }
            return iResult;
        }

    }
}
