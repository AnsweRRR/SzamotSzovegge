namespace SzamotSzovegge
{
    public static class NumberToText
    {
        public static string SzamotSzoveggeAlakit(long szam)
        {
            string[] EgyesStr = { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
            string[] TizesStr = { "", "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
            string[] TizenStr = { "", "tizen", "huszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };

            string Result = "";
            long Maradek;

            if (szam == 0)
            {
                Result = "Nulla";
            }
            else
            {
                Maradek = Math.Abs(szam);
                System.Diagnostics.Debug.Assert(Maradek <= 999999999999);
                Alakit(ref Maradek, 1000000000, "milliárd", ref Result, EgyesStr, TizesStr, TizenStr);
                Alakit(ref Maradek, 1000000, "millió", ref Result, EgyesStr, TizesStr, TizenStr);
                Alakit(ref Maradek, 1000, "ezer", ref Result, EgyesStr, TizesStr, TizenStr);
                Alakit(ref Maradek, 1, "", ref Result, EgyesStr, TizesStr, TizenStr);
                Result = char.ToUpper(Result[0]) + Result.Substring(1);
                if (szam < 0)
                {
                    Result = "Mínusz " + Result;
                }
            }

            return Result;
        }

        private static void Alakit(ref long Maradek, long Oszto, string Osztonev, ref string Result, string[] EgyesStr, string[] TizesStr, string[] TizenStr)
        {
            if (Maradek >= Oszto)
            {
                if (Result.Length > 0)
                {
                    Result += "-";
                }
                long Mit = Maradek / Oszto;
                if (Mit >= 100)
                {
                    Result += EgyesStr[Mit / 100] + "száz";
                }
                Mit %= 100;
                if (Mit % 10 != 0)
                {
                    Result += TizenStr[Mit / 10] + EgyesStr[Mit % 10] + Osztonev;
                }
                else
                {
                    Result += TizesStr[Mit / 10] + Osztonev;
                }
            }
            Maradek %= Oszto;
        }
    }
}
