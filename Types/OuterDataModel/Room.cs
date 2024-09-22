namespace Types.OuterDataModel
{
    class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Exits { get; set; }
        public string[] Items { get; set; }
        public string[] NPCs { get; set; }
    }
}