namespace Furniture
{
    public interface IFurniture { }
    public class WoodChair : IFurniture { }
    public class WoodTable : IFurniture { }
    public class SteelChair : IFurniture { }
    public class SteelTable : IFurniture { }
    public class IronChair : IFurniture { }
    public class IronTable : IFurniture { }

    public interface IFurnitureFactory
    {
        IFurniture GetChair();
        IFurniture GetTable();
    }

    public class WoodFurnitureFactory : IFurnitureFactory
    {
        public IFurniture GetChair()
        {
            return new WoodChair();
        }

        public IFurniture GetTable()
        {
            return new WoodTable();
        }
    }

    public class IronFurnitureFactory : IFurnitureFactory
    {
        public IFurniture GetChair()
        {
            return new IronChair();
        }

        public IFurniture GetTable()
        {
            return new IronTable();
        }
    }

    public class SteeFurniturelFactory : IFurnitureFactory
    {
        public IFurniture GetChair()
        {
            return new SteelChair();
        }

        public IFurniture GetTable()
        {
            return new SteelTable();
        }
    }

}
