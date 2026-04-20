using TextAdventure.Items;
using TextAdventure.NPCs;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class InterfacePassage : Room
    {
        public InterfacePassage() : base("Interface-Passage", "\nNorden --> Debugginglabor\nOsten --> Unused Refernces-Lager\nSüden --> Byte-Katakomben\nWesten --> Stackoverflowkammer", false)

        {
            //NPCs hinzufügen
            ByteSpider byteSpider = new ByteSpider();
            base.NPCs.Add(byteSpider);

            LightSwitch lightSwitch = new LightSwitch();
            base.Items.Add(lightSwitch);
        }
        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst die Interface-Passage.",
                "Du hörst im Dunkeln ein leises Zischen...."
            };
        }
    }
}
