using UnityEngine;

public class XpManager : MonoBehaviour
{
    public static float currentXP;
    public int playerLevel = 1;
    public float requiredXP;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentXP >= requiredXP)
        {
            currentXP = 0;
            LevelUp();

        }
    }
    void LevelUp()
    {
        playerLevel++;
    }
}
