using ChipmunkKingdoms.Scripts.Utility;

namespace _00.Works.HN.Code.EventSystems
{
    public static class AbilityEvents
    {
        public static readonly AbilitySelectEvent AbilitySelectEvent = new AbilitySelectEvent();
    }

    public class AbilitySelectEvent : GameEvent
    {
        public ComponentContainer owner;
        public Ability.Ability ability;

        public AbilitySelectEvent Initializer(ComponentContainer owner, Ability.Ability ability)
        {
            this.owner = owner;
            this.ability = ability;
            return this;
        }
    }
}