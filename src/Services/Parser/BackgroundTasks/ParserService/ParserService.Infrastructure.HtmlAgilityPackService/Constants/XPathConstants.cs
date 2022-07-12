namespace ParserService.Infrastructure.HtmlAgilityPackService.Constants
{
    public static class XPathConstants
    {
        public const string KufarAdLabel = "div/div/div/h3";
        public const string KufarAdCost = "div/div/div/p/span[1]";
        public const string OnlinerAdLink = "td[1]/table/tr/td[2]/div/table/tr/td/h2/a";
        public const string OnlinerAdLabel = "td[1]/table/tr/td[2]/div/table/tr/td/h2/a";
        public const string OnlinerAdCost = "td[2]/div[contains(@class, 'price-primary')]";
    }
}
