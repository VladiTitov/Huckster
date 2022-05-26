namespace Parser.Infrastructure.HtmlAgilityPackService.Models
{
    public class KufarAdModel : AdModel
    {
        public KufarAdModel(HtmlNode htmlNode)
        {
            UrlId = htmlNode
                .Attributes["href"]
                .Value;
            Link = htmlNode
                .Attributes["href"]
                .Value;
            Label = htmlNode
                .SelectSingleNode(XPathConstants.KufarAdLabel)?
                .InnerText;
            Cost = htmlNode
                .SelectSingleNode(XPathConstants.KufarAdCost)?
                .InnerText;
        }
    }
}
