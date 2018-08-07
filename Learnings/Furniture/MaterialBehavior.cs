namespace Furniture
{
    //implement a strategy pattern
    public interface IMaterialBehavior
    {
        bool FireTest();
        bool StressTest();
    }

    public class MaterialBehavior : IMaterialBehavior
    {
        public bool FireTest()
        {
            throw new System.NotImplementedException();
        }
        
        public bool StressTest()
        {
            throw new System.NotImplementedException();
        }
    }

    public class WoodMaterial : MaterialBehavior
    {

        public bool FireTest()
        {
            return false;
        }


        public bool StressTest()
        {
            return true;
        }
    }

    public class MetalMaterial : MaterialBehavior
    {

        public bool FireTest()
        {
            return true;
        }


        public bool StressTest()
        {
            return true;
        }
    }
}
