using TextAdventure.Items;
using TextAdventure.Players;

namespace TextAdventure.Rooms
{
    public class ByteCatacombs : Room
    {
        public ByteCatacombs() : base("Byte-Katakomben", "\nNorden --> Interface-Passage", false)
        {
            //Item 
            ExceptionScroll exceptionScroll = new ExceptionScroll();
            base.Items.Add(exceptionScroll);

            //Lichtschalter
            LightSwitch lightSwitch = new LightSwitch();
            base.Items.Add(lightSwitch);
        }

        public override string[] Enter(Player player)
        {
            return new string[] {
                "Du betrittst die Byte-Katakomben.",
                "Es ist stockdunkel, du kannst nichts sehen. Es riecht nach altem Code und vergessenen Bugs.",
            };
        }
    }
}
