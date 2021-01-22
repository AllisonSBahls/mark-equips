using MarkEquipsAPI.Data.DTOs;
using MarkEquipsAPI.Hypermedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace MarkEquipsAPI.Hypermedia.Enricher
{
    public class UserEnricher : ContentResponseEnricher<UserDto>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(UserDto content, IUrlHelper urlHelper)
        {
            var path = "api/v1/users";
            string _linkId = GetLink(content.Id, urlHelper, path);
            string _linkDefault= GetLinkDefault(urlHelper, path);
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = _linkId,
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
                Action = HttpActionVerb.PUT,
                Href = _linkDefault,
                Rel = RelationType.put,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = _linkId,
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
        private string GetLinkDefault(IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }

    }
}
