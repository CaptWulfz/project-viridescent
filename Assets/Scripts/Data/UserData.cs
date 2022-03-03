[System.Serializable]
public class UserData
{
    public int leaves;
    public int water;
    public int garden_level;


    public UserData(int leaves = 0, int water = 0, int gardenLevel = 0)
    {
        this.leaves = leaves;
        this.water = water;
        this.garden_level = gardenLevel;
    }
}
