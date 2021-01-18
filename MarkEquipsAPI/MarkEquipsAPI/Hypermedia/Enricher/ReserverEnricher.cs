using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Hypermedia.Enricher
{
    public class ReserverEnricher : ContentResponseEnricher<ReserverDto>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(ReserverDto content, IUrlHelper urlHelper)
        {
            var path = "api/v1/reservations";
            string _link = getLink(content.Id, urlHelper, path);
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = _link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = _link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = _link,
                Rel = RelationType.put,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = _link,
                Rel = RelationType.delete,
                Type = "int"
            });
            return null;
        }

        private string getLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }

    }
}
