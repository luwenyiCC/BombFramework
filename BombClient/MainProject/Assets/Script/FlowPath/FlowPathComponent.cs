using System;
using BombServer.Kernel;
using SequentialFSM;

public class FlowPathComponent : Component
{
    SequentialFSMControl SFSM;
    public FlowPathComponent()
    {
        SFSM = new SequentialFSMControl();

    }
}
