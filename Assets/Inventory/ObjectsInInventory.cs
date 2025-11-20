using System.Collections.Generic;

public static class ObjectsInInventory
{
    public static Dictionary<int, int> objectCounts = new Dictionary<int, int>();

    public static int totalSpeedBoost;
    public static int totalJumpBoost;
    public static int totalDamageBoost;
    public static int garlicAmount;

    public static bool swordEquiped;
    public static bool bowEquiped;

    public static void SetCount(int id, int amount)
    {
        objectCounts[id] = amount;
    }

    public static bool Consume(int id)
    {
        if (!objectCounts.ContainsKey(id) || objectCounts[id] <= 0)
            return false;

        objectCounts[id]--;
        return true;
    }

    public static void AddBack(int id)
    {
        if (!objectCounts.ContainsKey(id))
            objectCounts[id] = 0;

        objectCounts[id]++;
    }

    public static int GetCount(int id)
    {
        if (!objectCounts.ContainsKey(id))
            return 0;

        return objectCounts[id];
    }

    public static void AddBoost(int speed, int jump)
    {
        totalSpeedBoost += speed;
        totalJumpBoost += jump;
    }

    public static void RemoveBoost(int speed, int jump)
    {
        totalSpeedBoost -= speed;
        totalJumpBoost -= jump;
    }
}
