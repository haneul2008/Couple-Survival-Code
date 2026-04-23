using _00.Works.HN.Code.Upgrades;

namespace _00.Works.HN.Code.EventSystems
{
    public static class UpgradeEvents
    {
        public static readonly UpgradeEvent UpgradeEvent = new UpgradeEvent();
    }

    public class UpgradeEvent : GameEvent
    {
        public IUpgrade upgrade;

        public UpgradeEvent Initializer(IUpgrade upgrade)
        {
            this.upgrade = upgrade;
            return this;
        }
    }
}