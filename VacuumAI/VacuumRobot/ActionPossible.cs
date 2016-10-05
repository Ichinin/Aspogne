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
        private string m_sName = "toto";
        protected VacuumRobot.RobotAI m_RobotAI;

        public ActionPossible(VacuumRobot.RobotAI p_RobotAI)
        {
            m_RobotAI = p_RobotAI;
        }

        public abstract string Name();

        public abstract void Act();
    }

    /// <summary>
    /// A possible action is to aspirate dust.
    /// </summary>
    public class Aspirate : ActionPossible
    {
        private string m_sName = "Aspirate";

        public override string Name()
        {
            return m_sName;
        }

        public Aspirate(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

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

        public override string Name()
        {
            return m_sName;
        }

        public MoveRobot(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        public override void Act()
        {
            m_RobotAI.Move();
        }
    }

    /// <summary>
    /// A possible action is to grab jewels.
    /// </summary>
    public class Grab : ActionPossible
    {
        private string m_sName = "Grab";

        public override string Name()
        {
            return m_sName;
        }

        public Grab(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

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

        public override string Name()
        {
            return m_sName;
        }

        public DoNothing(VacuumRobot.RobotAI p_RobotAI) : base(p_RobotAI)
        {
        }

        public override void Act()
        {
            Thread.Sleep(500);
        }
    }
}
