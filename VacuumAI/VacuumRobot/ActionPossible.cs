using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    /// <summary>
    /// Defines the class of action that our agent may undertake
    /// Each subclass defines its own premises and consequences 
    /// </summary>
    class ActionPossible
    {
        public string name; 
        private void Act() { }
    }

    /// <summary>
    /// A possible action is to suck dust
    /// </summary>
    class Suck : ActionPossible
    {
        public new string name = "Suck";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to move the robot
    /// </summary>
    class MoveRobot : ActionPossible
    {
        public new string name = "MoveRobot";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to grab jewels
    /// </summary>
    class Grab : ActionPossible
    {
        public new string name = "Grab";

        private void Act()
        {
        }
    }

    /// <summary>
    /// A possible action is to do nothing 
    /// </summary>
    class DoNothing : ActionPossible
    {
        public new string name = "DoNothing";

        private void Act()
        {
        }
    }
}
