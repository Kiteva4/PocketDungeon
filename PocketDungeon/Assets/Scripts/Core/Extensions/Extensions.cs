public static class Extensions
{
    public static string Converter(this float value)
    {
        if (value > 1_000__000_000_000_000_000_000f)
        {
            return (value * 0.000_000_000_000_000_001f).ToString("0.00") + "BB";
        }

        else if (value > 1_000_000_000_000_000_000f)
        {
            return (value * 0.000_000_000_000_001f).ToString("0.00") + "MB";
        }

        else if (value > 1_000_000_000_000f)
        {
            return (value * 0.000_000_000_001f).ToString("0.00") + "KB";
        }

        else if (value > 1_000_000_000f)
        {
            return (value * 0.000_000_001f).ToString("0.00") + "B";
        }

        else if (value > 1_000_000f)
        {
            return (value / 1_000_000f).ToString("0.00") + "M";
        }

        else if (value > 1_000f)
        {
            return (value / 1_000f).ToString("0.00") + "K";
        }

        if (value < 1f) return 1.ToString();
        else return value.ToString("0");
    }
}
