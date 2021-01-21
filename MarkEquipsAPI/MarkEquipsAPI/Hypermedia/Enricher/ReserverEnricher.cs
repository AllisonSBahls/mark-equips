using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Constants;
using MarkEquipsAPI.Hypermedia.Utils;
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
            string _link = GetLink(content.Id, urlHelper, path);
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
                Href = urlHelper.Link("DefaultApi", new { controller = $"{ path }/asc/10/1" }),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Rel = "cancel-reserver",
                Action = HttpActionVerb.PATCH,
                Href = urlHelper.Link("DefaultApi", new { controller = $"{path}/cancel", id = content.Id}),
                Type = ResponseTypeFormat.DefaultPatch
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

        private string GetLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}
