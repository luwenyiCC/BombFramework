using System;
using HotFix_Project.Kernel;
//
using SequentialFSM;

namespace HotFix_Project
{
    public class FlowPathComponent : Component
    {
        public SequentialFSMControl fsm;
        public FlowPathComponent()
        {
            fsm = new SequentialFSMControl();

        }

    }
}
