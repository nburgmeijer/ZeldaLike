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

public class RoomSwitchEventInfo : EventInfo
{
    public string virtualCameraName;
}

public class BlendingEndEventInfo : EventInfo
{
}