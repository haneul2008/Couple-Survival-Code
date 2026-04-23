namespace _00.Works.HN.Code.Upgrades
{
    public interface IUpgrade
    {
        public int Level { get; }
        public bool IsMax();
        public void Upgrade();
    }
}