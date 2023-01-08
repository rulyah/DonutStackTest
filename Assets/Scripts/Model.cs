using System.Collections.Generic;

public static class Model
{
    public static List<Stick> sticks;
    public static List<Stick> suitableSticks;
    public static List<Stick> checkedSticks;
    public static Stick firstSuitableStick;
    public static Stick secondSuitableStick;
    public static Stick currentStick => sticks[^1];
}