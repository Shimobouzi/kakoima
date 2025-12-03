using System.Collections.Generic;

[System.Serializable]
public class ReplayData
{
    public int id;
    public List<InputLog> logs = new List<InputLog>();
}

[System.Serializable]
public struct InputLog
{
    public float horizontal;
    public bool jumpHeld;
}