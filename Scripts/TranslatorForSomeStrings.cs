public static class TranslatorForSomeStrings 
{
    public static string GetStringByKey(int key)
    {
        string language = "en";
        switch (key)
        {
            case 1:
                switch (language)
                {
                    case "en":
                        return "Attempt";
                }
                return "";
        }
        return "";
    }
}
