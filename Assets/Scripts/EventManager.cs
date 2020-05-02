using System;
using System.Collections.Generic;
//The EventManager class, static so it can be called from everywhere without instantiating it
//Generic types derived from EventInfo type
public static class EventManager<T> where T : EventInfo
{
    //dictionary to hold all the events as ActionDelegates. Key=>Eventinfo Type, Value=>Action delegate
    private static Dictionary<Type, Action<T>> eventListeners;
    //let's register a listener
    public static void RegisterListener(Action<T> listener)
    {
        
        //if null then make a new dictionary
        if (eventListeners == null)
        {
            eventListeners = new Dictionary<Type, Action<T>>();
        }
        //get the type we want to register
        Type eventType = typeof(T);
        //register the listener to the key
        if (!eventListeners.ContainsKey(eventType))
            eventListeners[eventType] = listener;
        else
            eventListeners[eventType] += listener;
    }

    public static void UnregisterListener(Action<T> listener)
    {
        //same as registering, but now we unsubscribe
        if (eventListeners == null)
        {
            return;
        }
        Type eventType = typeof(T);

        eventListeners[eventType] -= listener;
    }

    public static void InvokeEvent(T eventInfo)
    {
        //Get the type of the Event we want to invoke
        Type eventInfoType = typeof(T);
        
        if (eventListeners == null)
        {
            //noone is listening lets get out of here
            return;
        }
        //invoke the delegate of the type we want
        eventListeners[eventInfoType]?.Invoke(eventInfo);
    }  
}
