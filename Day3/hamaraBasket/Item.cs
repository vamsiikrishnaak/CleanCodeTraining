namespace hamaraBasket
{
    public interface Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {

        }

        //public override string ToString()
        //{
        //    return this.Name + ", " + this.SellIn + ", " + this.Quality;
        //}  
    }
}
