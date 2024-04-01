using UnityEngine;

public class infoItems{
    public static int water {get; set;} = 100;
    public static float[] getTimeFHuman(){
        return new float[]{15,30,60};
    }
    public static float[] getTimeFWater(){
        return new float[]{20,40,60};
    }
    public static float[] getTimeFAnimal(){
        return new float[]{10,25,60};
    }
}