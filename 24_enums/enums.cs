var ns = Transition(ServerState.Idle);
Console.WriteLine(ns.ToString().ToLower());

var ns2 = Transition(ns);
Console.WriteLine(ns2.ToString().ToLower());

static ServerState Transition(ServerState s) => s switch
{
    ServerState.Idle                               => ServerState.Connected,
    ServerState.Connected or ServerState.Retrying  => ServerState.Idle,
    ServerState.Error                              => ServerState.Error,
    _ => throw new Exception($"unknown state: {s}")
};

enum ServerState { Idle, Connected, Error, Retrying }
