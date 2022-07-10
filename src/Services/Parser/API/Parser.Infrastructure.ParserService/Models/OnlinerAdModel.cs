namespace Parser.Infrastructure.HtmlAgilityPackService.Models
{
    public class OnlinerAdModel : AdModel
    {
        public OnlinerAdModel(HtmlNode htmlNode)
        {
            if (htmlNode.InnerText.Contains("Аренда")) return;

            var adLink = htmlNode
                .SelectSingleNode(XPathConstants.OnlinerAdLink)
                .Attributes["href"]
                .Value;
            UrlId = adLink;
            Link = "https://baraholka.onliner.by" + adLink;
            Label = htmlNode
                .SelectSingleNode(XPathConstants.OnlinerAdLabel)?
                .InnerText;
            Cost = htmlNode
                .SelectSingleNode(XPathConstants.OnlinerAdCost)?
                .InnerText;
        }
    }
}
