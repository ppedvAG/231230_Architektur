namespace HalloBuilder
{
    internal class Schrank
    {
        private Schrank()
        { }

        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public int AnzahlBöden { get; private set; }
        public string Farbe { get; private set; }



        internal class Builder
        {
            Schrank schrank = new Schrank();

            public Schrank Create() { return schrank; }

            public Builder SetTüren(int anzTüren)
            {
                if (anzTüren < 0 || anzTüren > 8)
                    throw new ArgumentException("Ungültige Anzahl Türen");

                schrank.AnzahlTüren = anzTüren;

                return this;
            }

            public Builder SetBöden(int anzBöden)
            {
                if (anzBöden < 2 || anzBöden > 6)
                    throw new ArgumentException("Ungültige Anzahl Böden");

                schrank.AnzahlBöden = anzBöden;

                return this;
            }


            public Builder SetFarbe(string farbe)
            {
                schrank.Oberfläche = Oberfläche.Lackiert;
                schrank.Farbe = farbe;

                return this;
            }

            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                schrank.Oberfläche = oberfläche;

                if (oberfläche == Oberfläche.Gewachst || oberfläche == Oberfläche.Natur)
                    schrank.Farbe = "";

                return this;
            }
        }

    }

    enum Oberfläche
    {
        Natur,
        Gewachst,
        Lackiert
    }
}
