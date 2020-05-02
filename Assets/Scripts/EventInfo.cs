using Cinemachine;

public abstract class EventInfo
{
    public string EventDescription;
}

public class SignEnterEventInfo : EventInfo
{
    public string signInfo;
}

public class SignExitEventInfo : EventInfo
{
}

public class BlendingStartEventInfo : EventInfo
{
    public CinemachineClearShot clearShot;
}

public class BlendingEndEventInfo : EventInfo
{
    public CinemachineClearShot clearShot;
}