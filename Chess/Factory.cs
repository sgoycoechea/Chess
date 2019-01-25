namespace Chess
{
    class Factory
    {
        private static Factory instance;

        public static Factory GetInstance()
        {
            if (instance == null)
                instance = new Factory();
            return instance;
        }

        public IBoard GetIBoard()
        {
            return new Board();
        }
    }
}
