using System;
using System.Threading;

namespace MainProgram
{
    /// <summary>
    /// Defines the class of action that our agent may undertake
    /// Each subclass defines its own premises and consequences.
    /// </summary>
    public abstract class ActionPossible
    {
        /// <summary>
        /// Name of the action.
        /// </summary>
        private string m_sName;
        /// <summary>
        /// Robot which will perform the action.
        /// </summary>
        protected VacuumRobot.RobotAI m_RobotAI;

        /// <summary>
        /// Create a new ActionPossible which is one of the action the robot can perform.
        /// </summary>
        /// <param name="p_RobotAI"> The robot which will perform the action. </param>
        public ActionPossible(VacuumRobot.RobotAI p_RobotAI)
        {
            m_RobotAI = p_RobotAI;
        }

        /// <summary>
        /// Abstract getter for the action name.
        /// </summary>
        /// <returns></returns>
        public abstract string Name();

        /// <summary>
        /// Abstract method to perfrom an action.
        /// </summary>
        public abstract void Act();
    }

    /// <summary>
    /// A possible action is to aspirate dust.
    /// </summary>
    public class Aspirate : ActionPossible
    {
        private string m_sName = "Aspirate";

        /// <summary>
        /// Get the action name.
        /// </summary>
        /// <returns> The action name. </returns>
        public override string Name()
        {
            return m_sName;
        }

        /// <summary>
        /// Create a new Aspirate which inherite from ActionPossible.
        /// </summary>
        /// <param name="p_RobotAI"> The robot which will perform the action. </param>
        public Aspirate(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        /// <summary>
        /// Abstract method to perfrom the hoover method.
        /// </summary>
        public override void Act()
        {
            m_RobotAI.HooverEverything();
        }
    }

    /// <summary>
    /// A possible action is to move the robot.
    /// </summary>
    public class MoveRobot : ActionPossible
    {
        private string m_sName = "MoveRobot";

        /// <summary>
        /// Get the action name.
        /// </summary>
        /// <returns> the action name. </returns>
        public override string Name()
        {
            return m_sName;
        }

        /// <summary>
        /// Create a new MoveRobot which inherite from ActionPossible.
        /// </summary>
        /// <param name="p_RobotAI"> The robot which will perform the action. </param>
        public MoveRobot(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        /// <summary>
        /// Abstract method to perfrom the move method.
        /// </summary>
        public override void Act()
        {
            m_RobotAI.MoveRobot();
        }
    }

    /// <summary>
    /// A possible action is to grab jewels.
    /// </summary>
    public class Grab : ActionPossible
    {
        private string m_sName = "Grab";

        /// <summary>
        /// Get the action name.
        /// </summary>
        /// <returns> the action name. </returns>
        public override string Name()
        {
            return m_sName;
        }

        /// <summary>
        /// Create a new Grab which inherite from ActionPossible.
        /// </summary>
        /// <param name="p_RobotAI"> The robot which will perform the action. </param>
        public Grab(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        /// <summary>
        /// Abstract method to perfrom the PickUpJewel method.
        /// </summary>
        public override void Act()
        {
            m_RobotAI.PickUpJewel();
        }
    }

    /// <summary>
    /// A possible action is to do nothing.
    /// </summary>
    public class DoNothing : ActionPossible
    {
        private string m_sName = "DoNothing";

        /// <summary>
        /// Get the action name.
        /// </summary>
        /// <returns> The action name. </returns>
        public override string Name()
        {
            return m_sName;
        }

        /// <summary>
        /// Create a new DoNothing which inherite from ActionPossible.
        /// </summary>
        /// <param name="p_RobotAI"> The robot which will perform the action. </param>
        public DoNothing(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        /// <summary>
        /// Abstract method to do nothing, just wait on the same square.
        /// </summary>
        public override void Act()
        {
            Thread.Sleep(500);
            Console.Write("Doing nothing, saving some energy...\n");
        }
    }
}
