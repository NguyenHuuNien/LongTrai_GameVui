using UnityEngine;
public interface IDataChicken{
    public Vector3 getPosChicken();
    public void setPosChicken(Vector3 value);
    public int getHeartChicken();
    public void setHeartChicken(int heart);
    public float getDoiChicken();
    public void setDoiChicken(float doi);
    public ESex getSexChicken();
    public void setSexChicken(ESex sex);
}