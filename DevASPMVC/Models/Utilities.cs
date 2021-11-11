namespace DevASPMVC.Models
{
    public class Utilities
    {
        public static bool CheckFever(float temperature)
        {
            float feverTemp = 38f;

            return temperature > feverTemp;
        }

        public static bool CheckHypothermia(float temperature)
        {
            float hypothermiaTemp = 35f;

            return temperature < hypothermiaTemp;
        }
    }
}