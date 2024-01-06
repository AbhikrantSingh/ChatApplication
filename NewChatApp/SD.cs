namespace NewChatApp
{
    public static class SD
    {
        static SD() 
        {
            DealthyHallowRace = new Dictionary<string, int>();
            DealthyHallowRace.Add(Cloak, 0);
            DealthyHallowRace.Add(Stone, 0);
            DealthyHallowRace.Add(Wand, 0);
        }
        public const string Wand = "wand"; //{ get; set; }
        public const string Stone = "stone"; //{ get; set; }
        public const string Cloak = "cloak"; //{ get; set; }


        public static Dictionary<string, int> DealthyHallowRace;
    
    
    
    }
}
