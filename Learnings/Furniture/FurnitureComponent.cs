using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture
{
    //USing Composite pattern
    public class FurnitureComponent
    {
        IMaterialBehavior materialBehavior;
        public FurnitureComponent(IMaterialBehavior m)
        {
            materialBehavior = m;
        }

        public void AddComponent(FurnitureComponent com) { }

        public bool RunFireTest() { return false; }

    }

    public class FurnitureComposite : FurnitureComponent
    {
        List<FurnitureComponent> parts;

        public FurnitureComposite(IMaterialBehavior m) : base(m)
        {
            parts = new List<FurnitureComponent>();
        }
        public void AddComponent(FurnitureComponent com)
        {
            parts.Add(com);
        }

        public bool RunFireTest()
        {
            
            foreach(var com in parts)
            {
                if (!com.RunFireTest())
                    return false;
            }
            return true;
        }
    }
}
