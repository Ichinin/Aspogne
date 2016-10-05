namespace MainProgram
{
    /// <summary>
    /// Defines the class of action that our agent may undertake
    /// Each subclass defines its own premises and consequences.
    /// </summary>
    public class ActionPossible
    {
        private string m_sName;

        public string Name
        {
            get
            {
                return m_sName;
            }
        }

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to aspirate dust.
    /// </summary>
    public class Aspirate : ActionPossible
    {
        private string m_sName = "Aspirate";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to move the robot.
    /// </summary>
    public class MoveRobot : ActionPossible
    {
        private string m_sName = "MoveRobot";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to grab jewels.
    /// </summary>
    public class Grab : ActionPossible
    {
        private string m_sName = "Grab";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to do nothing.
    /// </summary>
    public class DoNothing : ActionPossible
    {
        private string m_sName = "DoNothing";

        private void Act()
        {
        }
    }
}
