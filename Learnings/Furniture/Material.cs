namespace Furniture
{
    public class Material : IMaterial
    {
        double heatThreshold, stressThreshold;
        public Material(double heatThreshold, double stressThreshold)
        {
            this.heatThreshold = heatThreshold;
            this.stressThreshold = stressThreshold;
        }
        public double GetHeatThreshold()
        {
            return heatThreshold;
        }

        public double GetStressThreshold()
        {
            return stressThreshold;
        }
       
    }

    public class Wood : Material
    {
        public Wood(double stressThreshold, double heatThreshold)
            : base(stressThreshold, heatThreshold)
        { }
    }
    public class Metal : Material
    {
        public Metal(double stressThreshold, double heatThreshold)
            : base(stressThreshold, heatThreshold)
        { }
    }
}
