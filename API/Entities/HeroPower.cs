namespace API.Entities
{
    public class HeroPower
    {
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
        public Power Power { get; set; }
        public int PowerId { get; set; }
    }
}